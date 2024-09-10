using exercise.pizzashopapi.Models.Order;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Order> GetOrdersByCustomer();

         Task<IResult> BecomeCustomer(IRepository repository);


         Task<IResult> UpdateOrder(IRepository repository);


         Task<IResult> OrderPizza(IRepository repository);


         Task<IResult> GetOrdersByCustomer(IRepository repository);


         Task<IResult> GetOrder(IRepository repository);


         Task<IResult> GetOrders(IRepository repository);


         Task<IResult> GetMenuItem(IRepository repository);


         Task<IResult> GetMenu(IRepository repository);

    }
}
