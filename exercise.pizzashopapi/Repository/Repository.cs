using System.Linq.Expressions;
using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _table = null;
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _table.ToList();
        }
        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
        }
        public async Task<T> Create(T entity)
        {
            _table.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            _table.Update(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var entity = await _table.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            _table.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
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

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
