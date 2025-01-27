using System.Linq.Expressions;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        Task Save();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetWithIncludes(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetWithThenIncludes(params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task<T> GetByIdWithIncludes(int id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdWithThenIncludes(int id, params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task<IEnumerable<T>> InsertAll(IEnumerable<T> entities);



    }
}
