using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table = null!;
        public Repository(DataContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }
        public Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetEntries(params Func<IQueryable<T>, IQueryable<T>>[] includes)
        {
            IQueryable<T> q = _table.AsQueryable();

            foreach (var inc in includes)
                q = inc.Invoke(q);

            return await q.ToArrayAsync();
        }

        public async Task<T?> GetEntry(Func<IQueryable<T>, IQueryable<T>> id, params Func<IQueryable<T>, IQueryable<T>>[] expressions)
        {
            IQueryable<T> q = _table.AsQueryable();

            q = id.Invoke(q);
            foreach (var ex in expressions)
            {
                q = ex.Invoke(q);
            }

            return await q.FirstOrDefaultAsync();
        }
        public async Task<T?> CreateEntry(T entry)
        {
            var a = await _table.AddAsync(entry);
            await _db.SaveChangesAsync();
            return entry;

        }

        public async Task<IEnumerable<T>> GetEntries()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetEntry(int id)
        {
            return await _table.FindAsync(id);
        }
    }
}
