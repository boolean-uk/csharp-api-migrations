using exercise.pizzashopapi.Models.Order;

namespace exercise.pizzashopapi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<IResult> BecomeCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetMenu(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetMenuItem(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetOrders(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetOrdersByCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> OrderPizza(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }
    }
}
