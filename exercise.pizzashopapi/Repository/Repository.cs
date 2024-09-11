using Microsoft.EntityFrameworkCore;
using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }
        public IEnumerable<Order> GetOrdersByCustomer(int id)
        {
            return _db.Orders;
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            var pizzas = await _db.Pizzas.ToListAsync();
            return pizzas;
        }
        public async Task<List<Order>> GetOrders()
        {
            var orders = await _db.Orders.ToListAsync();
            return orders;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            var pizza = await _db.Pizzas.FirstOrDefaultAsync(x => x.Id == id);
            return pizza;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }
    }
}
