using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int id);

        Task<IEnumerable<T>> GetEntries();
        Task<IEnumerable<T>> GetEntries(params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task<T?> GetEntry(Func<IQueryable<T>, IQueryable<T>> id, params Func<IQueryable<T>, IQueryable<T>>[] expressions);
        Task<T?> GetEntry(int id);

        Task<T?> CreateEntry(T entry);
    
    }
}
