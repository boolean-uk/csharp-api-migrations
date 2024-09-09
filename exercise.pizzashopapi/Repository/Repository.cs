using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public IEnumerable<Order> GetOrdersByCustomer(int id)
        {
            return _db.ord
        }
    }
}
