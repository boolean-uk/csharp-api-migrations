using exercise.pizzashopapi.Models;
using System.Numerics;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<List<Pizza>> GetPizzas();
        Task<Pizza> GetPizzaById(int id);
        Task<Pizza> CreatePizza(Pizza pizza);
        Task<List<Order>> GetOrders();
        Task<List<Order>> GetOrderByCustomerId(int id);
        Task<Order> CreateOrder(Order order);

    }
}
