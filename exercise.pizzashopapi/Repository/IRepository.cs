using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Models.DTOs;
using System.Linq.Expressions;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includes);
        Task<T> Create(T entity);

        Task<Order> UpdateOrder(int id, UpdateOrderDTO order);

        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
    }
}
