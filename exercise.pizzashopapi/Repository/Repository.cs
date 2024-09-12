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
            return await _db.Orders
                .Include(a => a.Customer)
                .Include(b => b.Pizza)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders
                .Where(o => o.CustomerID == id)
                .Include(a => a.Customer)
                .Include(b => b.Pizza)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var entity = await _db.Customers
                .Include(a => a.Orders)
                .ThenInclude(b => b.Pizza)
                .FirstOrDefaultAsync(a => a.Id == id);

            return entity;
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }
    }
}
