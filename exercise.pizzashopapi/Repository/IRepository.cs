using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        Task<Order> GetOrdersByCustomer(int id);
        

    }
}
