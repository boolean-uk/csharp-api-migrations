using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace exercise.pizzashopapi.Repository
{
    public class Repository<Model> : IRepository<Model>
        where Model : class
    {
        private DataContext _db;
        private DbSet<Model> _dbSet;

        public Repository(DataContext db)
        {
            _db = db;
            _dbSet = _db.Set<Model>();
        }

        public async Task<Model> Create(string[] inclusions, Model model)
        {
            _dbSet.Add(model);
            await _db.SaveChangesAsync();
            foreach (string inclusion in inclusions)
            {
                await _db.Entry(model).Reference(inclusion).LoadAsync();
            }
            return model;
        }

        public async Task<Model> Get(string[] inclusions, Expression<Func<Model, bool>> predicate)
        {
            var query = _dbSet.AsQueryable();
            foreach (string inclusion in inclusions)
            {
                query = query.Include(inclusion);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Model>> GetAll(string[] inclusions, Expression<Func<Model, bool>> predicate)
        {
            var query = _dbSet.AsQueryable();
            foreach (string inclusion in inclusions)
            {
                query = query.Include(inclusion);
            }
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Model>> GetAll(string[] inclusions)
        {
            var query = _dbSet.AsQueryable();
            foreach (string inclusion in inclusions)
            {
                query = query.Include(inclusion);
            }
            return await query.ToListAsync();
        }

        public async Task<Model> Update(string[] inclusions, Model model)
        {
            _dbSet.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            foreach (string inclusion in inclusions)
            {
                await _db.Entry(model).Reference(inclusion).LoadAsync();
            }
            return model;
        }
    }
}
