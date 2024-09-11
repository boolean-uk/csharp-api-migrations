using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.ViewModels;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        public Task<OrderDTO> AddOrder(Order entity);
        public Task<IEnumerable<OrderDTO>> GetOrders();
        public Task<OrderDTO> GetOrderById(int id);
        public Task<OrderDTO> GetOrderByCustomerId(int id);
        public Task<OrderDTO> RemoveOrder(int id);
        public Task<OrderDTO> OrderDelivered(int id);
        public Task<PizzaDTO> AddPizza(Pizza entity);
        public Task<IEnumerable<PizzaDTO>> GetPizzas();
        public Task<PizzaDTO> GetPizzaById(int id);
        public Task<CustomerDTO> AddCustomer(Customer entity);
        public Task<IEnumerable<CustomerDTO>> GetCustomers();
        public Task<CustomerDTO> GetCustomerById(int id);
    }
}
