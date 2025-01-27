using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<Pizza> GetPizza(int id);
        Task<Pizza> AddPizza(Pizza pizza);

        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
        Task<Customer> AddCustomer(Customer customer);
        
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
        Task<IEnumerable<Order>> GetOrdersByDriver(int id);

        Task<IEnumerable<OrderToppings>> GetOrderToppingsByOrder(int id);
        Task<OrderToppings> GetOrderTopping(int id);
        Task<IEnumerable<OrderToppings>> GetOrderToppings();
        Task<OrderToppings> AddOrderToppings(OrderToppings orderToppings);

        Task<Topping> GetTopping(int id);
        Task<Topping> AddTopping(Topping topping);
        Task<IEnumerable<Topping>> GetToppings();

        Task<DeliveryDriver> GetDriver(int? id);

    }
}
