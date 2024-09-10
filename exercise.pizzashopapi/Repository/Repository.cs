using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models.Order;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        public Task<IResult> BecomeCustomer(IRepository repository, string Name)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetMenu(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetMenuItem(IRepository repository, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetOrder(IRepository repository,int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetOrders(IRepository repository)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByCustomer(int id, int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> OrderPizza(IRepository repository, int pizzaId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateOrder(IRepository repository, int orderId, Order newOrder)
        {
            throw new NotImplementedException();
        }
    }
}
