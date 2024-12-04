using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Reflection;

namespace exercise.pizzashopapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _dbSet;

        public Repository(DataContext db) 
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllWithIncludes()
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    // Skip including the main type itself
                    if (property.PropertyType != typeof(T))
                    {
                        query = query.Include(property.Name);

                        // Handle ThenInclude for nested properties
                        foreach (var nestedProperty in property.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            if (nestedProperty.PropertyType.IsClass && nestedProperty.PropertyType != typeof(string) && nestedProperty.PropertyType != typeof(T))
                            {
                                query = query.Include($"{property.Name}.{nestedProperty.Name}");
                            }
                        }
                    }
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdWithIncludes(int id)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    // Skip including the main type itself
                    if (property.PropertyType != typeof(T))
                    {
                        query = query.Include(property.Name);

                        // Handle ThenInclude for nested properties
                        foreach (var nestedProperty in property.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            if (nestedProperty.PropertyType.IsClass && nestedProperty.PropertyType != typeof(string) && nestedProperty.PropertyType != typeof(T))
                            {
                                query = query.Include($"{property.Name}.{nestedProperty.Name}");
                            }
                        }
                    }
                }
            }
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }


    }
}
