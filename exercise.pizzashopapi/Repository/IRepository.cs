using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        // TODO: move Dto out of Repository layer
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomer(int id);
        Task<Customer?> CreateCustomer(CustomerPostDto customer);

        Task<IEnumerable<DeliveryDriver>> GetDeliveryDrivers();
        Task<DeliveryDriver?> GetDeliveryDriver(int id);
        Task<DeliveryDriver?> CreateDeliveryDriver(DeliveryDriverPostDto deliveryDriver);

        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<IEnumerable<Order>> GetOrdersByDriver(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> CreateOrder(OrderPostDto order);

        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza?> CreatePizza(PizzaPostDto pizza);

        Task<IEnumerable<Topping>> GetToppings();
        Task<Topping?> CreateTopping(ToppingDto topping);
    }
}
