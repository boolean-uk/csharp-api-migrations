using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {

        private readonly DataContext _datacontext;

        public Repository(DataContext context)
        {
            _datacontext = context;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _datacontext.Orders.Include(o => o.Customer).Include(o => o.Pizza).ToList();
        }
    }
}
