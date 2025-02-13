using System.Linq.Expressions;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task Save();
        IQueryable<T> GetWithIncludes(params Expression<Func<T, object>>[] includes);
    }
}
