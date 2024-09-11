using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace exercise.pizzashopapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;   

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); ;
        }

        public async Task<IEnumerable<T>> getAllWithIncludes()
        {

            IQueryable<T> query = _dbSet.AsQueryable();
            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if(property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    query = query.Include(property.Name);
                }
            }
            return await query.ToListAsync();
        }


        public async Task<T> getByIdWithIncludes(int id)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            
            foreach(var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if(property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    query = query.Include(property.Name);
                }
            }
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task<T>  Add(T entity)
            {

                _dbSet.Add(entity);
                _context.SaveChanges();
                 return entity;
              }

        public async Task<T> Delete(int id)
        {
            var entity = _dbSet.Find(id);   
            if (entity == null)
            {
                return null;
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        

        public async Task<IEnumerable<T>> getAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> getbyId(int id)
        {
            if (id == null)
            {
                return null;
            }

            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                return null;
            }

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
