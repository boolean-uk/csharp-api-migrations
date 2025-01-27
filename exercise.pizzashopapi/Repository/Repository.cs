using System.Linq.Expressions;
using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table = null!;

        public Repository(DataContext dataContext)
        {
            _db = dataContext;
            _table = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return _table.ToList();
        }

        public async Task<T> Insert(T entity)
        {
            _table.Add(entity);
            _db.SaveChanges();
            return entity;
        }
        public async Task<IEnumerable<T>> InsertAll(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
            _db.SaveChanges();
            return entities;
        }

        public async Task<T> Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> Delete(object id)
        {
            T entity = _table.Find(id);
            _table.Remove(entity);
            _db.SaveChanges();
            return entity;
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
        public async Task<T> GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table.Where(e => EF.Property<int>(e, "Id") == id);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetWithThenIncludes(
                params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
            {
                query = include(query);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdWithThenIncludes(int id,
            params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> query = _table.Where(e => EF.Property<int>(e, "Id") == id);
            foreach (var include in includes)
            {
                query = include(query);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            _db.SaveChangesAsync();
        }

    }
}
