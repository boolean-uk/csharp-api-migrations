using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Order>> GetOrders();
        Task<Order>GetOrderById(int id);
        Task<Pizza> GetPizzaById(int id);
        Task<Toppings> GetToppingsById(int id);
    }
}
