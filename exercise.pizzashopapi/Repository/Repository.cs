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

        public async Task<Customer> GetCustomerById(int id)
        {
             return await _db.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.Include(c => c.Orders).ToListAsync();  
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return  await _db.Orders.Include(o=>o.Customer).Include(o=>o.Pizza).ToListAsync();
            
        }

        public async  Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Include(o => o.Pizza).Include(o => o.Customer).Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByPizza(int id)
        {
            return await _db.Orders.Include(o => o.Pizza).Include(o => o.Customer).Where(o => o.PizzaId == id).ToListAsync();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            return await _db.Pizzas.Include(p => p.Orders).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.Include(p=>p.Orders).ToListAsync() ;
        }
    }
}
