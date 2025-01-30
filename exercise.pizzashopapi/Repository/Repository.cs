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
            this._db = db;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders
                .Include(x => x.Customer)
                .Include(x => x.Pizza)
                .Include(x => x.DeliveryDriver)
                .Include(x => x.OrderToppings)
                .ThenInclude(x => x.Topping)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders
                .Where(x => x.CustomerId == id)
                .Include(x => x.Customer)
                .Include(x => x.Pizza)
                .Include(x => x.DeliveryDriver)
                .Include(x => x.OrderToppings)
                .ThenInclude(x => x.Topping)
                .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByDeliveryDriver(int id)
        {
            return await _db.Orders
                .Where(x => x.DeliveryDriverId == id)
                .Include(x => x.Customer)
                .Include(x => x.Pizza)
                .Include(x => x.DeliveryDriver)
                .Include(x => x.OrderToppings)
                .ThenInclude(x => x.Topping)
                .ToListAsync();
        }
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }
        public async Task<IEnumerable<Topping>> GetToppings()
        {
            return await _db.Toppings.ToListAsync();
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers
                .Include(x => x.Orders)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderToppings)
                .ThenInclude(x => x.Topping)
                .Include(x => x.Orders)
                .ThenInclude(x => x.DeliveryDriver)
                .ToListAsync();
        }
        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _db
                .Customers.Include(c => c.Orders)
                .ThenInclude(o => o.DeliveryDriver)
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<DeliveryDriver>> GetDeliveryDrivers()
        {
            return await _db.DeliveryDrivers
                .Include(x => x.Orders)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderToppings)
                .ThenInclude(x => x.Topping)
                .Include(x => x.Orders)
                .ThenInclude(x => x.Customer)
                .ToListAsync();
        }
        public async Task<DeliveryDriver?> GetDeliveryDriver(int id)
        {
            return await _db.DeliveryDrivers
                .Include(x => x.Orders)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.Orders)
                .ThenInclude(x => x.OrderToppings)
                .ThenInclude(x => x.Topping)
                .Include(x => x.Orders)
                .ThenInclude(x => x.Customer)
                .FirstOrDefaultAsync(d => d.Id == id);
        }


        public async Task<Order> AddOrder(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            await _db.Pizzas.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<Topping> AddTopping(Topping topping)
        {
            await _db.Toppings.AddAsync(topping);
            await _db.SaveChangesAsync();
            return topping;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<DeliveryDriver> AddDeliveryDriver(DeliveryDriver deliveryDriver)
        {
            await _db.DeliveryDrivers.AddAsync(deliveryDriver);
            await _db.SaveChangesAsync();
            return deliveryDriver;
        }
    }
}
