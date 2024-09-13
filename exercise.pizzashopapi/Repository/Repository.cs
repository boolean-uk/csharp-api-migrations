using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using exercise.pizzashopapi.Models.DTOs;

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

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task<T> Create(T entity)
        {
            _dbSet.Add(entity);

            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers
                .Include(c => c.Order)
                .ThenInclude(o => o.Pizza)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _db.Customers
                .Include(c => c.Order)
                .ThenInclude(o => o.Pizza)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Order> UpdateOrder(int id, UpdateOrderDTO order)
        {
            var orderToUpdate = await _db.Orders.FindAsync(id);
            orderToUpdate.Status = order.Status;
            await _db.SaveChangesAsync();

            return orderToUpdate;
        }
    }
}
