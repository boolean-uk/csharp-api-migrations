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

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
           return order;
        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            _db.Pizzas.Add(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
           return await _db.Customers.Include(o => o.Orders).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {

            return await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).Where(x => x.CustomerId == id).ToListAsync();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }
    }
}
