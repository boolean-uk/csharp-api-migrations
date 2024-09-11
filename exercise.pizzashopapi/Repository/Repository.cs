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

        // Orders
        public async Task<Order> GetOrder(int id)
        {
            return await _db.Orders.Include(o => o.Customer).Include(o => o.Pizza).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.Include(o => o.Pizza).Include(o => o.Customer).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Include(o => o.Customer).Include(o => o.Pizza).Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<Order> CreateOrder(NewOrder newOrder)
        {
            Order order = new Order()
            {
                CustomerId = newOrder.CustomerId,
                PizzaId = newOrder.PizzaId,
                Stage = "Preparing",
                Pickup = DateTime.UtcNow
            };

            if(!_db.Customers.Any(c => c.Id == newOrder.CustomerId) && !_db.Pizzas.Any(p => p.Id == newOrder.PizzaId))
            {
                return null;
            }

            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
            return _db.Orders.FirstOrDefault(o => o.Id == order.Id);

        }

        public async Task<Order> DeliverOrder(int id)
        {
            Order order = await _db.Orders.Include(o => o.Customer).Include(o => o.Pizza).FirstOrDefaultAsync(o => o.Id ==  id);
            if(order == null)
            {
                return null;
            }
            order.Stage = "Delivered";
            await _db.SaveChangesAsync();
            return order;
        }

        // Pizzas
        public async Task<Pizza> GetPizza(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }


        // Customers
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.Include(c => c.Orders).ThenInclude(o => o.Pizza).ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _db.Customers.Include(c => c.Orders).ThenInclude(o => o.Pizza).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
