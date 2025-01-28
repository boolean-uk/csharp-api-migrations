using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext db;

        public Repository(DataContext db)
        {
            this.db = db;
        }

        public async Task<Customer?> CreateCustomer(CustomerPostDto customer)
        {
            var c = new Customer() { Name = customer.Name };
            var result = db.Customers.Add(c);
            await db.SaveChangesAsync();
            return await GetCustomer(result.Entity.Id);
        }

        public async Task<DeliveryDriver?> CreateDeliveryDriver(
            DeliveryDriverPostDto deliveryDriver
        )
        {
            var driver = new DeliveryDriver() { Name = deliveryDriver.Name };
            var result = db.DeliveryDrivers.Add(driver);
            await db.SaveChangesAsync();
            return await GetDeliveryDriver(result.Entity.Id);
        }

        public async Task<Order?> CreateOrder(OrderPostDto order)
        {
            var o = new Order()
            {
                PizzaId = order.PizzaId,
                CustomerId = order.CustomerId,
                DeliveryDriverId = order.DeliveryDriverId,
            };
            var result = db.Orders.Add(o);
            await db.SaveChangesAsync();
            int orderId = result.Entity.Id;
            foreach (int toppingId in order.ToppingIds)
            {
                var pt = new OrderToppings() { OrderId = orderId, ToppingId = toppingId };
                db.OrderToppings.Add(pt);
            }
            await db.SaveChangesAsync();

            return await db
                .Orders.Include(o => o.Pizza)
                .Include(o => o.DeliveryDriver)
                .Include(o => o.Customer)
                .Include(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Pizza?> CreatePizza(PizzaPostDto pizza)
        {
            var p = new Pizza { Name = pizza.Name, Price = pizza.Price };
            var result = db.Pizzas.Add(p);
            await db.SaveChangesAsync();
            return await db.Pizzas.FirstOrDefaultAsync(p => p.Id == result.Entity.Id);
        }

        public async Task<Topping?> CreateTopping(ToppingDto topping)
        {
            var t = new Topping { Name = topping.Name, Price = topping.Price };
            var result = db.Toppings.Add(t);
            await db.SaveChangesAsync();
            return await db.Toppings.FirstOrDefaultAsync(t => t.Id == result.Entity.Id);
        }

        public async Task<Customer?> GetCustomer(int id)
        {
            return await db
                .Customers.Include(c => c.Orders)
                .ThenInclude(o => o.DeliveryDriver)
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await db
                .Customers.Include(c => c.Orders)
                .ThenInclude(o => o.DeliveryDriver)
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .ToListAsync();
        }

        public async Task<DeliveryDriver?> GetDeliveryDriver(int id)
        {
            return await db
                .DeliveryDrivers.Include(c => c.Orders)
                .ThenInclude(o => o.Customer)
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DeliveryDriver>> GetDeliveryDrivers()
        {
            return await db
                .DeliveryDrivers.Include(c => c.Orders)
                .ThenInclude(o => o.Customer)
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await db
                .Orders.Include(o => o.Pizza)
                .Include(o => o.DeliveryDriver)
                .Include(o => o.Customer)
                .Include(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await db
                .Orders.Include(o => o.DeliveryDriver)
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .Include(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .Where(o => o.CustomerId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByDriver(int id)
        {
            return await db
                .Orders.Include(o => o.DeliveryDriver)
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .Include(o => o.OrderToppings)
                .ThenInclude(ot => ot.Topping)
                .Where(o => o.DeliveryDriverId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await db.Pizzas.ToListAsync();
        }

        public async Task<IEnumerable<Topping>> GetToppings()
        {
            return await db.Toppings.ToListAsync();
        }
    }
}
