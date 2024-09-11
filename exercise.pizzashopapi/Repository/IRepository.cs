using System.Reflection;
namespace exercise.pizzashopapi.Repository
{
    public interface IRepository <T> where T : class
    {


        Task<IEnumerable<T>> getAll();

        Task<IEnumerable<T>> getAllWithIncludes();

        Task<T> getByIdWithIncludes(int id);


        Task<T> getbyId(int id);

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(int id);



    }
}
