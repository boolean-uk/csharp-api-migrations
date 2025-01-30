using System.Threading.Tasks;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<IEnumerable<Order>> GetOrdersByDeliveryDriver(int id);
        Task<Order> AddOrder(Order order);
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> AddPizza(Pizza pizza);

        Task<IEnumerable<Topping>> GetToppings();
        Task<Topping> AddTopping(Topping topping);

        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomerById(int id);
        Task<Customer> AddCustomer(Customer customer);

        Task<IEnumerable<DeliveryDriver>> GetDeliveryDrivers();
        Task<DeliveryDriver?> GetDeliveryDriver(int id);
        Task<DeliveryDriver> AddDeliveryDriver(DeliveryDriver deliveryDriver);


    }
}
