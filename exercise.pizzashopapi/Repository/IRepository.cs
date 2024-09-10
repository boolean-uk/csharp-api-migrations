using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<Customer> AddCusomer(int id, string name);
        Task<Order> AddOrder(int pizzaId, int customerId);
        Task<Pizza> AddPizza(int id, string name, int price);
        Task<Customer> GetACusomer(int id);
        Task<Order> GetAnOrder(int pizzaId, int customerId);
        Task<Pizza> GetAPizza(int id);
        Task<IEnumerable<Customer>> GetCusomers();
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Pizza>> GetPizzas();
    }
}
