using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        public IEnumerable<Order> GetOrders()
        {
            using (var db = new DataContext())
            {
                return db.Orders.Include(o => o.Customer).Include(o => o.Pizza).ToList();
            }
        }
    }
}
