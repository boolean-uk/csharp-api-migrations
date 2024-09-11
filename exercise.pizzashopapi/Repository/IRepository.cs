using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<List<Pizza>> GetAllPizzas();
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);

        Task<Pizza> GetPizza(int id);

        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomer(int id);

        Task<Order> GetOrder(int id);

        Task<Customer> AddCustomer(Customer customer);

        Task<Order> AddOrder(Order order);
        

    }
}
