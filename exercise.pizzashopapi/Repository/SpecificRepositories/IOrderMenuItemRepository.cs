using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository.GenericRepositories;

namespace exercise.pizzashopapi.Repository.SpecificRepositories
{
    public interface IOrderMenuItemRepository : IRepository<OrderMenuItem>
    {
        Task AddMenuItemToOrder(int orderId, int menuItemId, int quantity);
        Task<IEnumerable<OrderMenuItem>> GetMenuItemsByOrder(int orderId);
    }
}
