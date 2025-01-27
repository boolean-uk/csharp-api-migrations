using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace exercise.pizzashopapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table = null;

        public Repository(DataContext dataContext)
        {
            _db = dataContext;
            _table = _db.Set<T>();
        }
        public async Task<IEnumerable<T>> Get()
        {
            return _table.ToList();
        }
        public async Task<T> Add(T entity)
        {
            _table.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
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
        public IQueryable<T> GetQueryable()
        {
            return _table;
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
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders
                .Where(o => o.CustomerId == id)
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .Include(o => o.Toppings)
                    .ThenInclude(ot => ot.Topping)
                .Include(o => o.Products)
                    .ThenInclude(op => op.Product)
                .ToListAsync();
        }
    }
}
