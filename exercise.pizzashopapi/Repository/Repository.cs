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

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _db.Customers.Include(c => c.Orders).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders(int? customerId)
        {
            if (customerId == null) return await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).ToListAsync();

            return await _db.Orders.Where(o => o.CustomerId == customerId).Include(c => c.Customer).Include(p => p.Pizza).ToListAsync();

        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            return await _db.Pizzas.Include(p => p.Orders).ToListAsync();
        }

        // Used optional customerId parameter in GetAllOrders instead
        public Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
