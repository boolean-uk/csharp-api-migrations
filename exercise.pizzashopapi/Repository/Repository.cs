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

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders
                .Include(a => a.Customer)
                .Include(b => b.Pizza)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders
                .Where(o => o.CustomerID == id)
                .Include(a => a.Customer)
                .Include(b => b.Pizza)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var entity = await _db.Customers
                .Include(a => a.Orders)
                .ThenInclude(b => b.Pizza)
                .FirstOrDefaultAsync(a => a.Id == id);

            return entity;
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas.FirstAsync(a => a.Id == id);
        }

        public async Task<Pizza> CreatePizza(Pizza entity)
        {
            _db.Pizzas.Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<Customer> CreateCustomer(Customer entity)
        {
            _db.Customers.Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<Order> CreateOrder(Order entity)
        {
            _db.Orders.Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<Order> GetOrderByIds(int pizzaID, int customerID)
        {
            var entity = await _db.Orders
                .Include(a => a.Customer)
                .Include(b => b.Pizza)
                .FirstAsync(o => o.PizzaID == pizzaID & o.CustomerID == customerID);

            return entity;
        }
    }
}
