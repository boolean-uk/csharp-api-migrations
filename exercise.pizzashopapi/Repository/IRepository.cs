using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> DeleteOrder(int id);
        Task<Order> CreateOrder(Order order);
        Task<Pizza> GetPizza(int id);
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> DeletePizza(int id);
        Task<Pizza> CreatePizza(Pizza pizza);
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> DeleteCustomer(int id);
        Task<Customer> CreateCustomer(Customer customer);
    }
}
