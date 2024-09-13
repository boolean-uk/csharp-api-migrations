using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<Pizza> CreatePizza(Pizza pizza);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int id);
        Task<IEnumerable<Pizza>> GetPizzas();

    }
}
