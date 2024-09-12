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
           return await _db.Customers.Include(o => o.Orders).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {

            return await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).Where(x => x.CustomerId == id).ToListAsync();
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }
    }
}
