using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T> where T : class
    {
        //IEnumerable<Order> GetOrdersByCustomer();
        Task<T> Create(T entity);
        Task<T> GetByIdWithIncludes(int id);

        Task<IEnumerable<T>> GetAllWithIncludes();
    }
}
