using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;
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
            return await _table.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWithNestedIncludes(Func<IQueryable<T>, IQueryable<T>> configureQuery)
        {
            IQueryable<T> query = _table;

            query = configureQuery(query);

            return await query.ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            _table.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<T>> InsertRange(IEnumerable<T> entities)
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

        public async Task<T> GetById(params object[] keyValues)
        {
            return _table.Find(keyValues);
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

        public async Task<T> GetByIdWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdWithNestedIncludes(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IQueryable<T>> configureQuery)
        {
            IQueryable<T> query = _table;

            query = configureQuery(query);

            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task Save()
        {
            _db.SaveChangesAsync();
        }
    }
}
