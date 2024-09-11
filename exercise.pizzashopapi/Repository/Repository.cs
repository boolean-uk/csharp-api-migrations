using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        // ------ Orders ------
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .Where(o => o.CustomerId == id)
                .ToListAsync();
        }
        public async Task<Order> GetOrderById(int customerId, int pizzaId)
        {
            return await _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .FirstOrDefaultAsync(o => o.CustomerId == customerId && 
                                          o.PizzaId == pizzaId);
        }
        public async Task<Order> CreateOrder(Order entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Order> DeleteOrder(int customerId, int pizzaId)
        {
            var target = await _db.Orders.FirstOrDefaultAsync(o => o.CustomerId == customerId && o.PizzaId == pizzaId);
            if (target == null)
            {
                return null;
            }
            _db.Orders.Remove(target);
            await _db.SaveChangesAsync();
            return target;
        }
        public async Task<Order> UpdateOrder(Order entity)
        {
            var target = await _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .FirstOrDefaultAsync(o => o.CustomerId == entity.CustomerId &&
                                          o.PizzaId == entity.PizzaId);
            target.CustomerId = entity.CustomerId;
            target.PizzaId = entity.PizzaId;
            target.Delivered = entity.Delivered;

            return entity;
        }


        //  ------ Customers ------

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers
                .Include(c => c.Order)
                .ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _db.Customers
                .Include(c => c.Order)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Customer> CreateCustomer(Customer entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Customer> DeleteCustomer(int id)
        {
            var target = await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (target == null)
            {
                return null;
            }
            _db.Customers.Remove(target);
            await _db.SaveChangesAsync();
            return target;
        }

        // ------ Pizzas ------
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas
                .Include(p => p.Order)
                .ToListAsync();
        }
        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Pizza> CreatePizza(Pizza entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Pizza> DeletePizza(int id)
        {
            var target = await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            if (target == null)
            {
                return null;
            }
            _db.Pizzas.Remove(target);
            await _db.SaveChangesAsync();
            return target;
        }
    }
}
