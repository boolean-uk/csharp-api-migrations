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

        public async Task<T> Create(T entity)
        {
            
            _table.Add(entity);
            await _db.SaveChangesAsync();
            return entity;

        }

        public async Task <IEnumerable<T>> Get()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Save()
        {
           await _db.SaveChangesAsync();
        }
    }
}
