using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models.Order;

namespace exercise.pizzashopapi.Repository
{
    public class Repository
    {
        private DataContext _db;
        public IEnumerable<Order> GetOrdersByCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
