using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Order>> GetOrdersByCustomer(int id);



    }
}
