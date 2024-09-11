using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        // Orders
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task<Order> CreateOrder(NewOrder newOrder);
        Task<Order> DeliverOrder(int id);

        // Pizzas
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> GetPizza(int id);

        // Cusomters
        Task<IEnumerable<Customer>> GetCustomers();    
        Task<Customer> GetCustomer(int id);
    }
}
