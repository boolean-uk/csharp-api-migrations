using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public async Task<Order> GetOrdersByCustomer(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
