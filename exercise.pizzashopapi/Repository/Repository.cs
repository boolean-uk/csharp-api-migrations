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

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _db.Orders.Include(o => o.Pizza).Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _db.Orders.Include(o => o.Pizza).Include(c => c.Customer).FirstOrDefaultAsync(c => c.Id == id);

            return order;

        }

        public async Task<IEnumerable<Order>> GetOrders()
        { 
        

            var orders = await _db.Orders.Include( o => o.Customer).Include(o => o.Pizza).ToListAsync();

            return orders;
        
        }


        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            var pizzas = await _db.Pizzas.ToListAsync(); 

            return pizzas;
        
        }

        public async Task<Pizza> GetPizzaById(int id)
        { 

            var pizza = await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);  

            return pizza;
            
        
        }


        public async Task<IEnumerable<Customer>> GetCustomers()
        { 
            var customers = await _db.Customers.ToListAsync();

            return customers;
        
        
        }


        public async Task<Customer> GetCustomerById(int id)
        { 
        
            var customer =  await _db.Customers.Include(c => c.Orders).ThenInclude(c => c.Pizza).FirstOrDefaultAsync(c => c.Id == id);

            return customer;
        
        }

    }  

    
       
}
