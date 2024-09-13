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

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            _db.Pizzas.Add(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer is null) return null;
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Order> DeleteOrder(int customerId, int pizzaId)
        {
            var order = _db.Orders.Find(customerId, pizzaId);
            if (order is null) return null;
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<Pizza> DeletePizza(int id)
        {
            var pizza = _db.Pizzas.Find(id);
            if (pizza is null) return null;
            _db.Pizzas.Remove(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _db.Orders.Include(o => o.Customer).Include(p => p.Pizza).ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public async Task<Customer> GetCustomer(string name)
        {
            return await _db.Customers.FirstOrDefaultAsync(o => o.Name == name);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Order> GetOrder(int pizzaId, int customerId)
        {
            return await _db.Orders.Include(o => o.Customer).Include(p => p.Pizza).FirstOrDefaultAsync(o => o.CustomerId == customerId && o.PizzaId == pizzaId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Include(o => o.Customer).Include(p => p.Pizza).Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<Pizza> GetPizza(int id)
        {
            return await _db.Pizzas.FindAsync(id);
        }

        public async Task<Pizza> GetPizza(string name)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
            return order;
        }
    }
}
