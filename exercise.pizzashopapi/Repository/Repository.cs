using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<List<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            var pizza = await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            if (pizza == null) return null;
            return pizza;

        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            await _db.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(p => p.Id == id);
            if (customer == null) return null;
            return customer;

        }

        public async Task<List<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();

        }
      

        public async Task<List<Order>> GetOrderByCustomerId(int id)
        {
            return await _db.Orders.Where(o => o.CustomerId == id).ToListAsync();
        }


        public async Task<Order> CreateOrder(Order order)
        {
            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

       

    }
}
