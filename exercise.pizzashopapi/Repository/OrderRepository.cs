using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class OrderRepository : Repository<Order>
    {

        private readonly DataContext _context;
        private readonly DbSet<Order> _orders;

        public OrderRepository(DataContext context) : base(context)
        {
            _context = context;
            _orders = context.Orders;
        }

        public async Task<Order> updateOrderStatus(int id, bool status)
        {
            var order = await getbyId(id);
            if (order == null)
            {
                return null;
            }
            order.delivered = status;
            _context.SaveChanges();
            return order;
        }
    }
}
