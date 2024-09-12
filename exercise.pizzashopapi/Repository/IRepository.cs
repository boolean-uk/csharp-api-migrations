using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T>
    {
        Task <IEnumerable<T>> Get();
        Task <T> Create(T entity);
        Task<T> GetById(int id);
        Task Save();
        Task<T> Update(T entity);
    }
}
