using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Pizza>> GetAllPizzas();
        public Task<Pizza> GetPizza(int id);
        public Task<Pizza> AddPizza(Pizza pizza);
        
        public Task<IEnumerable<Customer>> GetAllCustomers();
        public Task<Customer> GetCustomer(int id);
        public Task<Customer> AddCustomer(Customer customer);
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<Order> GetOrder(int id);
        public Task<Order> AddOrder(Order order);
        public Task<IEnumerable<Order>> GetOrdersByCustomerId(int id);

    }
}
