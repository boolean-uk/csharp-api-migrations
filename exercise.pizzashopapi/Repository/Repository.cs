using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        //public IEnumerable<Order> GetOrdersByCustomer(int id)
        //{
        //    //return _db.ord
        //}
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<string> GetCustomerNameById(int id)
        {
            var found = await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return found.Name;
        }

        public async Task<string> GetPizzaNameById(int id)
        {
            var found = await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            return found.Name;
        }

        public async Task<decimal> GetPizzaPriceById(int id)
        {
            var found = await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            return found.Price;
        }



        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();
        }
    }
}
