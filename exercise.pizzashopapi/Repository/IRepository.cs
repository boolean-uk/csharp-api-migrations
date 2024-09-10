using exercise.pizzashopapi.Models.Order;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Order> GetOrdersByCustomer();

         Task<IResult> BecomeCustomer();


         Task<IResult> UpdateOrder();


         Task<IResult> OrderPizza();


         Task<IResult> GetOrdersByCustomer();


         Task<IResult> GetOrder();


         Task<IResult> GetOrders();


         Task<IResult> GetMenuItem();


         Task<IResult> GetMenu();

    }
}
