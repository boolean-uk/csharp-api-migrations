using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using exercise.pizzashopapi.Data;
using Microsoft.EntityFrameworkCore;


namespace workshop.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table = null!;
        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            _table.Add(entity);
            _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            _db.SaveChanges();
            return existing;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return _table.ToList();
        }

        public async Task<T> GetById(int id)
        {
            return _table.Find(id);
        }

        public async Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWithNestedIncludes(params Func<IQueryable<T>, IQueryable<T>>[] includeActions)
        {
            IQueryable<T> query = _table;

            foreach (var includeAction in includeActions)
            {
                query = includeAction(query);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(entity => EF.Property<int>(entity, "Id") == id);
        }

        public async Task Save()
        {
            _db.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return entity;
        }

        public IQueryable<T> GetQuery()
        {
            return _table;
        }
    }
}
