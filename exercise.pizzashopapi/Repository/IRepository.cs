using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId);
        Task<Order> GetOrderById(int customerId, int pizzaId);
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrderStatus(Order order);

        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> GetPizzaById(int id);
        Task<Pizza> AddPizza(Pizza pizza);

        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
    }
}
