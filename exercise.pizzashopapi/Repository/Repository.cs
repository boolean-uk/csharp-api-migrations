using System.Linq.Expressions;
using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    // CRUD = Create, Read, Update, Delete
    public class Repository<T> : IRepository<T> where T : class
    {
        private DatabaseContext _db;
        private DbSet<T> _table = null!;

        public Repository(DatabaseContext dataContext)
        {
            _db = dataContext;
            _table = _db.Set<T>();
        }

        // Create
        public async Task<T> Insert(T entity)
        {
            try
            {
                _table.Add(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting entity", ex);
            }
        }

        // Read
        public async Task<IEnumerable<T>> Get()
        {
            return await _table.ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
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

        // Update
        public async Task<T> Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }

        // Delete
        public async Task<T> Delete(object id)
        {
            T entity = await _table.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Entity not found for deletion.");
            }

            _table.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        // Save
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
