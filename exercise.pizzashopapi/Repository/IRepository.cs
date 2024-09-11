using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Order> GetOrdersByCustomer(int id);
        
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<List<Order>> GetOrders();
        Task<List<Customer>> GetCustomers();
        Task<Order> GetOrderById(int id);
        Task<Pizza> GetPizzaById(int id);
        Task<Customer> GetCustomerById(int id);

    }
}
