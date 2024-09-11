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
            this._db = db;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();
            return await GetCustomer(customer.Id);
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return await GetOrder(order.Id);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = await _db.Customers.ToListAsync();
            return customers;
        }

        public async Task<List<Pizza>> GetAllPizzas()
        {
            List<Pizza> pizzas = await _db.Pizzas.ToListAsync();
            return pizzas;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = await _db.Customers.SingleOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public async Task<Order> GetOrder(int id)
        {
            Order order = await _db.Orders.SingleOrDefaultAsync( x => x.Id == id);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            IEnumerable<Order> orders = await _db.Orders.Where( x => x.CustomerId == id).ToListAsync();
            return orders;
        }
        public async Task<Pizza> GetPizza(int id)
        {
            Pizza pizza = await _db.Pizzas.SingleOrDefaultAsync(x => x.Id == id);
            return pizza;
        }
    }
}
