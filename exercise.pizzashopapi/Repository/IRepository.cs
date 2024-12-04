using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllWithIncludes();
        Task<T> GetByIdWithIncludes(int id);
        Task<T> Create(T entity);
    }
}
