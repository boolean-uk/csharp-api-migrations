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

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();
        }
        public async Task<Customer> GetCustomer(int id)
        {
            return await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task<Pizza> GetPizza(int id)
        {
            return await _db.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<Pizza> UpdatePizza(int id, Pizza pizza)
        {
            var pizzaToEdit = await _db.Pizzas.FindAsync(id);

            if (pizzaToEdit == null)
            {
                return null; // Or handle not found appropriately (e.g., throw an exception)
            }

            // Update properties
            pizzaToEdit.Name = pizza.Name;
            pizzaToEdit.Price = pizza.Price;

            _db.Pizzas.Update(pizzaToEdit);
            await _db.SaveChangesAsync();

            return pizzaToEdit;
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            var customerToEdit = await _db.Customers.FindAsync(id);

            if (customer == null)
            {
                return null; // Or handle not found appropriately (e.g., throw an exception)
            }

            // Update properties
            customerToEdit.Name = customer.Name;

            _db.Customers.Update(customerToEdit);
            await _db.SaveChangesAsync();

            return customerToEdit;
        }

        public async Task<Order> UpdateOrder(int id, Order order)
        {
            Order orderToEdit = await _db.Orders.FindAsync(id);
            if(orderToEdit == null)
            {
                return null;
            };
            orderToEdit.CustomerId = order.CustomerId;
            orderToEdit.PizzaId = order.PizzaId;
            orderToEdit.Date = order.Date;

            _db.Orders.Update(orderToEdit);
            await _db.SaveChangesAsync();

            return orderToEdit;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customerToDelete = await _db.Customers.FindAsync(id);

            if (customerToDelete == null)
            {
                return null; // Or handle appropriately (e.g., throw an exception)
            }

            _db.Customers.Remove(customerToDelete);
            await _db.SaveChangesAsync();

            return customerToDelete;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var orderToDelete = await _db.Orders.FindAsync(id);

            if (orderToDelete == null)
            {
                return null; // Or handle appropriately (e.g., throw an exception)
            }

            _db.Orders.Remove(orderToDelete);
            await _db.SaveChangesAsync();

            return orderToDelete;
        }

        public async Task<Pizza> DeletePizza(int id)
        {
            var pizzaToDelete = await _db.Pizzas.FindAsync(id);

            if (pizzaToDelete == null)
            {
                return null; // Or handle appropriately (e.g., throw an exception)
            }

            _db.Pizzas.Remove(pizzaToDelete);
            await _db.SaveChangesAsync();

            return pizzaToDelete;
        }

        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            await _db.Pizzas.AddAsync(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<PizzaTopping> AddTopping(PizzaTopping topping)
        {
            await _db.Toppings.AddAsync(topping);
            await _db.SaveChangesAsync();
            return topping;
        }

        public async Task<Pizza> AddToppingToPizza(int pizzaId, int toppingId)
        {
            Pizza pizza = await _db.Pizzas.Include(p => p.Toppings).FirstOrDefaultAsync(p => p.Id == pizzaId);
            PizzaTopping pizzaTopping = await _db.Toppings.FirstOrDefaultAsync(t => t.Id == toppingId);

            pizza.Toppings.Add(pizzaTopping);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<Driver> AddDriver(Driver driver)
        {
            await _db.Drivers.AddAsync(driver);
            await _db.SaveChangesAsync();
            return driver;
        }

        public async Task<Order> AddDriverToOrder(int orderId, int driverId)
        {
            Order order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            Driver driver = await _db.Drivers.FirstOrDefaultAsync(d => d.Id == driverId);

            order.DriverId = driverId;
            await _db.SaveChangesAsync();
            return order;

        }

        public async Task<IEnumerable<Order>> GetAllOrdersForDriverID(int driverId)
        {
            return await _db.Orders.Where(o => o.DriverId == driverId).ToListAsync();
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            return await _db.Drivers.ToListAsync();
        }
    }
}
