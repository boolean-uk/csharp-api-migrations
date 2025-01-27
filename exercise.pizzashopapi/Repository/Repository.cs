using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
