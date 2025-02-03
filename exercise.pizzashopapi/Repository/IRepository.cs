using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T>
    {
    Task<IEnumerable<T>> GetAll();

    Task<T> GetEntityById(int id);
    Task<T> UpdateEntityById(int id, T entity);
    Task<T> CreateEntity(T entity);
    Task<T> DeleteEntityById(int id);
    public bool Exists(Func<T, bool> exist);
        

    }
}
