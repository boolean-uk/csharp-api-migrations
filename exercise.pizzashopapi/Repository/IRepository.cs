using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int id);
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);


        Task<List<Order>> GetOrders();

        Task<Order> GetOrderById(int id);


        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> GetPizzaById(int id);
     
        

    }
}
