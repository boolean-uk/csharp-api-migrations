using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository(DataContext db) : IRepository
    {
        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            return await db.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetPizza(int id)
        {
            return (await db.Pizzas.FirstOrDefaultAsync(p => p.Id == id))!;
        }

        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            await db.Pizzas.AddAsync(pizza);
            await db.SaveChangesAsync();
            return pizza;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await db.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return (await db.Customers
                .Include(c => c.Orders)
                .ThenInclude(c => c.Pizza)
                .FirstOrDefaultAsync(c => c.Id == id))!;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await db.Customers.AddAsync(customer);
            await db.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await db.Orders
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return (await db.Orders.FirstOrDefaultAsync(o => o.Id == id))!;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int id)
        {
            throw new NotImplementedException("TODO!");
        }
    }
}
