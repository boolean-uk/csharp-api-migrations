using System.Linq.Expressions;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task Save();
        Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetWithNestedIncludes(params Func<IQueryable<T>, IQueryable<T>>[] includeActions);

        IQueryable<T> GetQuery();


    }
}
