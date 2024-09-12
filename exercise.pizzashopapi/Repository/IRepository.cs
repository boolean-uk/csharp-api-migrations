using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<Customer> GetCustomerById(int id);
        Task<Pizza> GetPizzaById(int id);
        Task<Pizza> CreatePizza(Pizza entity);
        Task<Customer> CreateCustomer(Customer entity);
        Task<Order> CreateOrder(Order entity);
        Task<Order> GetOrderByIds(int pizzaID, int customerID);
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Pizza>> GetPizzas();
    }
}
