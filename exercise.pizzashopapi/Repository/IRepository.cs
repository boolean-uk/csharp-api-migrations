using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Order> CreateOrder(Order order);
        Task<Pizza> CreatePizza(Pizza pizza);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<Pizza> GetPizzaById(int id);
        Task<IEnumerable<Pizza>> GetPizzas();
    }
}
