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

        public async Task<Customer> AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Order> AddOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<OrderToppings> AddOrderToppings(OrderToppings orderToppings)
        {
            _db.OrderToppings.Add(orderToppings);
            await _db.SaveChangesAsync();
            return orderToppings;
        }

        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            _db.Pizzas.Add(pizza);
            await _db.SaveChangesAsync();
            return pizza;
        }

        public async Task<Topping> AddTopping(Topping topping)
        {
            _db.Toppings.Add(topping);
            await _db.SaveChangesAsync();
            return topping;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _db.Orders.FindAsync(id);
        }

        public async Task<DeliveryDriver> GetDriver(int? id)
        {
            return await _db.DeliveryDrivers.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            return await _db.Orders.Where(o => o.CustomerId == id).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByDriver(int id)
        {
            return await _db.Orders.Where(o => o.DriverId == id).ToListAsync();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var target = await _db.Orders.FindAsync(order.Id);
            _db.Orders.Remove(target);
            await _db.SaveChangesAsync();

            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<OrderToppings> GetOrderTopping(int id)
        {
            return await _db.OrderToppings.FindAsync(id);
        }

        public async Task<IEnumerable<OrderToppings>> GetOrderToppings()
        {
            return await _db.OrderToppings.ToListAsync();
        }

        public async Task<IEnumerable<OrderToppings>> GetOrderToppingsByOrder(int id)
        {
            return await _db.OrderToppings.Where(o => o.OrderId==id).ToListAsync();
        }

        public async Task<Pizza> GetPizza(int id)
        {
            return await _db.Pizzas.FindAsync(id);
        }

        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _db.Pizzas.ToListAsync();
        }

        public async Task<Topping> GetTopping(int id)
        {
            return await _db.Toppings.FindAsync(id);
        }

        public async Task<IEnumerable<Topping>> GetToppings()
        {
            return await _db.Toppings.ToListAsync();
        }
    }
}
