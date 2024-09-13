using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{


    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db) //dependency injection of the db context class.so
        {
            _db = db;
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Where(a => a.CustomerId == id).ToListAsync();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Pizza> CreatePizza(Pizza entity)
        {
            _db.Pizzas.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
       public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.Include(o => o.Orders).ThenInclude(p => p.pizza).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _db.Customers.Include(o => o.Orders).ThenInclude(p => p.pizza).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Customer> CreateCustomer(Customer entity)
        {
            _db.Customers.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
