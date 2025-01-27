using System.Linq.Expressions;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T?> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
