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
        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            List<Order> orders = await _db.Orders.Include(a => a.customer).Include(b => b.pizza).ToListAsync();
            var order = orders.FindAll(a => a.customerId == id);
            return order;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            List<Order> orders = await _db.Orders.Include(a => a.customer).Include(b => b.pizza).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            List<Pizza> pizzas = await _db.Pizzas.ToListAsync();
            return pizzas;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            List<Customer> customers = await _db.Customers.ToListAsync();
            return customers;
        }

        public async Task<IEnumerable<Customer>> GetCustomer(int id)
        {
            List<Customer> customers = await _db.Customers.ToListAsync();
            return customers.FindAll(x => x.Id == id);
        }
    }
}
