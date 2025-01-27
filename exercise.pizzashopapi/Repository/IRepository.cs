using exercise.pizzashopapi.Models;
using System.Linq.Expressions;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task Save();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetWithNestedIncludes(params Func<IQueryable<T>, IQueryable<T>>[] includeActions);
        IQueryable<T> GetQueryable();
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
    }
}
