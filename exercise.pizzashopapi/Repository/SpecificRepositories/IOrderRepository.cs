using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository.GenericRepositories;

namespace exercise.pizzashopapi.Repository.SpecificRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId);
        Task<IEnumerable<Order>> GetOrdersByDriver(int driverId);
        Task<IEnumerable<Order>> GetAllOrdersWithDetails();
    }
}
