using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class OrderRepository : Repository<Order>
    {

        private readonly DataContext _db;

        public OrderRepository(DataContext context) : base(context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _db.Orders
                 .Include(o => o.Pizza)
                 .Include(o => o.Customer)
                 .Where(o => o.CustomerId == customerId)
                 .ToListAsync();
        }

        public async Task<Order> UdateOrderStatus(int customerId, int pizzaId, string status)
        {
            Order order = await _db.Orders
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.CustomerId == customerId && o.PizzaId == pizzaId);

            order.Status = status;
            await _db.SaveChangesAsync();
            return order;

        }

    }
}
