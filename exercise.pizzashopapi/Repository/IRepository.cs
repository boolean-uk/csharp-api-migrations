using exercise.pizzashopapi.Models.Customer;
using exercise.pizzashopapi.Models.Order;
using exercise.pizzashopapi.Models.Pizza;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
         CustomerDTO BecomeCustomer(string Name);


         OrderDTO UpdateOrder(int orderId, int pizzaId);


         OrderDTO OrderPizza(int pizzaId, int customerId);


         List<OrderDTO> GetOrdersByCustomer(int customerId);


         OrderDTO GetOrder(int orderId);


         List<OrderDTO> GetOrders();


         PizzaDTO GetMenuItem(int pizzaId);


         List<PizzaDTO> GetMenu();

        OrderDTO DeliverPizza(int pizzaId);

    }
}
