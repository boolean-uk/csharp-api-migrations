using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<Customer> AddCusomer(int id, string name)
        {
            await _db.Customers.AddAsync(new Customer { Id = id, Name = name });
            await _db.SaveChangesAsync();
            return new Customer { Id = id, Name = name };
        }

        public async Task<Order> AddOrder(int pizzaId, int customerId)
        {
            await _db.Orders.AddAsync(new Order { PizzaId = pizzaId, CustomerId = customerId });
            await _db.SaveChangesAsync();
            return new Order { PizzaId = pizzaId, CustomerId = customerId };
        }

        public async Task<Pizza> AddPizza(int id, string name, int price)
        {
            await _db.Pizzas.AddAsync(new Pizza { Id = id, Name = name, Price = price });
            await _db.SaveChangesAsync();
            return new Pizza { Id = id, Name = name, Price = price }; 
        }

        public async Task<Customer> GetACusomer(int id)
        {
            return await _db.Customers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Order> GetAnOrder(int pizzaId, int customerId)
        {
            return await _db.Orders.FirstOrDefaultAsync(p => p.PizzaId == pizzaId && p.CustomerId == customerId);
        }

        public async Task<Pizza> GetAPizza(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetCusomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }
    }
}
