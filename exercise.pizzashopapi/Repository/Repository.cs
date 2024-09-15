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
            return await _db.Orders.Include(o => o.CustomerOnOrder).Include(o => o.PizzaOnOrder).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _db.Orders.Include(o => o.CustomerOnOrder).Include(o => o.PizzaOnOrder).Where(o => o.CustomerId == customerId).ToListAsync();
        }
        public async Task<Order> AddOrder(Order order)
        {
            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }



        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }
        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            await _db.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }


        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
