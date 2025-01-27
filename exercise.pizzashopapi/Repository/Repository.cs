using System.Linq.Expressions;
using exercise.pizzashopapi.Data;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository;

public class Repository<T>(DataContext db) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);

        return await query.Where(predicate).ToListAsync();
    }

    public async Task<T?> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);

        return await query.FirstOrDefaultAsync(predicate);
    }
}