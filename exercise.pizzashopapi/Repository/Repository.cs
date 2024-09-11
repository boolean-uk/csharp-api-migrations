using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        public IEnumerable<Order> GetOrdersByCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
