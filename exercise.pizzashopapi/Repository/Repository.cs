using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await _db.AddAsync(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            await _db.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders
                .Include(x => x.pizza)
                .Include(x => x.customer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int id)
        {
            return await _db.Orders
                .Include(x => x.pizza)
                .Include(x => x.customer)
                .Where(x => x.CustomerId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }        
    }
}
