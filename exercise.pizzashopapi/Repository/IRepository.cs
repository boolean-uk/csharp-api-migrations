using System.Linq.Expressions;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T, U>
        where T : class
        where U : struct
    {
        Task<IEnumerable<T>> GetAll(params Func<IQueryable<T>, IQueryable<T>>[] includeChains);

        Task<T> Get(U id, string idField, params Func<IQueryable<T>, IQueryable<T>>[] includeChains);
        Task<T> Get(U id, params Func<IQueryable<T>, IQueryable<T>>[] includeChains);


        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(U id);
        Task Save();
        Task<T> Find(Expression<Func<T, bool>> condition, params Func<IQueryable<T>, IQueryable<T>>[] includeChains);
        Task<IEnumerable<T>> FindAll(
            Expression<Func<T, bool>>? condition = null, 
            Expression<Func<T, object>>? orderBy = null, 
            bool ascending = true, 
            params Func<IQueryable<T>, IQueryable<T>>[] includeChains);
    }
}
