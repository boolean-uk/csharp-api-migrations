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
              /*  var orders = from order in db.Orders
                    join pizza in db.Pizzas on order.PizzaId equals pizza.Id
                    join customer in db.Customers on order.CustomerId equals customer.Id
                    select new Order
                    {
                    Id = order.Id,
                    Pizza = pizza,
                    Customer = customer,
                                              
                    };

                return orders.ToList();*/
            }
        }
    }
}

