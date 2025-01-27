using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> GetPizza(int id);
        Task<Pizza> AddPizza(Pizza pizza);
        Task<Pizza> AddToppingToPizza(int pizzaId, int toppingId);

        Task<Pizza> UpdatePizza(int id, Pizza pizza);
        Task<Pizza> DeletePizza(int id);

        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(int id, Customer customer);
        Task<Customer> DeleteCustomer(int id);

        Task<IEnumerable<Order>> GetOrders();
        Task<Order> AddOrder(Order order);
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);

        Task<Order> GetOrder(int id);
        Task<Order> UpdateOrder(int id, Order order);
        Task<Order> DeleteOrder(int id);

        Task<Driver> AddDriver(Driver driver);
        Task<Order> AddDriverToOrder(int orderId, int driverId);
        Task<List<Driver>> GetAllDrivers();
        Task<IEnumerable<Order>> GetAllOrdersForDriverID(int driverId);

    }
}

