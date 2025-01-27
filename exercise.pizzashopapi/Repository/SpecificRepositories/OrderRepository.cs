using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository.SpecificRepositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly DataContext _dbContext;

        public OrderRepository(DataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId)
        {
            return await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .Include(o => o.DeliveryDriver)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByDriver(int driverId)
        {
            return await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .Include(o => o.DeliveryDriver)
                .Where(o => o.DeliveryDriverId == driverId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithDetails()
        {
            return await _dbContext.Orders
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .Include(o => o.DeliveryDriver)
                .Include(o => o.OrderMenuItems) 
                    .ThenInclude(omi => omi.MenuItem)
                .ToListAsync();
        }

    }
}
