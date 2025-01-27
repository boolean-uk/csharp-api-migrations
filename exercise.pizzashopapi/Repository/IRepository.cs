using exercise.pizzashopapi.Models;
using System.Linq.Expressions;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> GetWithNestedIncludes(Func<IQueryable<T>, IQueryable<T>> configureQuery);
        Task<T> Insert(T entity);
        Task<IEnumerable<T>> InsertRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task Save();
        Task<T> GetById(params object[] keyValues);
        Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdWithNestedIncludes(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> configureQuery);
    }
}
