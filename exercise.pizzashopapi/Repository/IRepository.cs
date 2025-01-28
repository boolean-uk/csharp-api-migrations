using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        public Task<IEnumerable<Order>> GetOrders();
        public Task<IEnumerable<Pizza>> GetPizzas();
        public Task<IEnumerable<Customer>> GetCustomers();
        public Task<IEnumerable<Customer>> GetCustomer(int id);

    }
}
