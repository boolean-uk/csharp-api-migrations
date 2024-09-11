using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> GetSinglePizza(int id);
        Task<Pizza> CreatePizza(Pizza pizza);
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> CreateOrder(Order order);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetSingleCustomer(int id);
        Task<Customer> CreateCustomer(Customer customer);
    }
}
