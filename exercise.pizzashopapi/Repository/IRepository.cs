using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);

        Task<IEnumerable<Order>> GetOrdersByPizza(int id);


        Task<IEnumerable<Order>> GetOrders();


        Task<IEnumerable<Customer>> GetCustomers();

        Task<IEnumerable<Pizza>> GetPizzas();


        Task<Customer> GetCustomerById(int id);

        Task<Pizza> GetPizzaById(int id);












    }
}
