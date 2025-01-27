using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);

        Task<IEnumerable<Order>> GetAllOrders(int? customerId);

        Task<IEnumerable<Pizza>> GetAllPizzas();

        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
