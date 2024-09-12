using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Pizza>> GetPizzas();
    }
}
