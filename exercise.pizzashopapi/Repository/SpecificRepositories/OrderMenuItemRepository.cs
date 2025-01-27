using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository.SpecificRepositories
{
    public class OrderMenuItemRepository : Repository<OrderMenuItem>, IOrderMenuItemRepository
    {
        private readonly DataContext _context;

        public OrderMenuItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddMenuItemToOrder(int orderId, int menuItemId, int quantity)
        {
            var existingEntry = await _context.OrderMenuItems
                .FirstOrDefaultAsync(omi => omi.OrderId == orderId && omi.MenuItemId == menuItemId);

            if (existingEntry != null)
            {
                existingEntry.Quantity += quantity; // Increase quantity if the item already exists
            }
            else
            {
                var orderMenuItem = new OrderMenuItem
                {
                    OrderId = orderId,
                    MenuItemId = menuItemId,
                    Quantity = quantity 
                };
                _context.OrderMenuItems.Add(orderMenuItem);
            }

            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<OrderMenuItem>> GetMenuItemsByOrder(int orderId)
        {
            return await _context.OrderMenuItems
                .Include(omi => omi.MenuItem)
                .Where(omi => omi.OrderId == orderId)
                .ToListAsync();
        }
    }
}
