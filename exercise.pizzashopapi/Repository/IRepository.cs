using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Order>> GetOrders();
        Task<Order>GetOrderById(int id);
        Task<Product> GetProductById(int id);
        Task<Toppings> GetToppingsById(int id);
    }
}
