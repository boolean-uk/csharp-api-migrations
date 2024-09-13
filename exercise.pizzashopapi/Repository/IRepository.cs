using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        //IEnumerable<Order> GetOrdersByCustomer();
        Task<IEnumerable<Order>> GetOrders();
        Task<string> GetCustomerNameById(int id);
        Task<int> GetCustomerIdByName(string name);
        Task<string> GetPizzaNameById(int id);
        Task<int> GetPizzaIdByName(string name);
        Task<decimal> GetPizzaPriceById(int id);
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId);
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order order);


    }
}
