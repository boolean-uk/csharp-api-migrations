﻿using exercise.pizzashopapi.Data;
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

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }
        public async Task<Pizza> GetSinglePizza(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            await _db.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.Include(o => o.Pizza).Include(o => o.customer).ToListAsync();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _db.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Include(o => o.Pizza).Include(o => o.customer).Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<Customer> GetSingleCustomer(int id)
        {
            return await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await _db.AddAsync(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Order> DeliverOrder(int customerId, int pizzaId)
        {

            Order order = await _db.Orders.FirstOrDefaultAsync(o => customerId == o.CustomerId && pizzaId == o.PizzaId);
            if(order == null)
            {
                return null;
            }
            order.PizzaStatus = "Delivered";
            await _db.SaveChangesAsync();
            return order;
        }
    }
}
