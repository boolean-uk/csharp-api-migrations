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
        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            List<Order> orders = await _db.Orders.Include(a => a.customer).Include(b => b.pizzas).ToListAsync();
            var order = orders.FindAll(a => a.Id == id);
            return order;
        }
    }
}
