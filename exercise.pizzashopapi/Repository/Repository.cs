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

        public async Task<string> GetCustomerNameById(int id)
        {
            var found = await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return found.Name;
        }

        public async Task<int> GetCustomerIdByName(string name)
        {
            var found = await _db.Customers.FirstOrDefaultAsync(c => c.Name == name);
            if (found != null)
            {
                return found.Id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<string> GetPizzaNameById(int id)
        {
            var found = await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            return found.Name;
        }
        public async Task<int> GetPizzaIdByName(string name)
        {

            var found = await _db.Pizzas.FirstOrDefaultAsync(c => c.Name == name);
            if (found != null)
            {
                return found.Id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<decimal> GetPizzaPriceById(int id)
        {
            var found = await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            return found.Price;
        }



        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _db.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }
    }
}
