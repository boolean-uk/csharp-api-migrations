using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        // ------ Orders ------
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<Order> GetOrderById(int customerId, int pizzaId);
        Task<Order> CreateOrder(Order entity);
        Task<Order> DeleteOrder(int customerId, int pizzaI);

        // ------ Pizza ------
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> GetPizzaById(int id);
        Task<Pizza> CreatePizza(Pizza entity);
        Task<Pizza> DeletePizza(int id);

        // ------ Pizza ------
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateCustomer(Customer entity);
        Task<Customer> DeleteCustomer(int id);

    }
}
