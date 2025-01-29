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

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int id)
        {
            IEnumerable<Order>orders = await _db.Orders.Where(x => x.customerId == id).Include(o => o.toppings).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _db.Customers.Include(c => c.Orders).ToListAsync();
            return customers;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return _db.Orders.Where(x => x.orderId == id).FirstOrDefault()!;
        }

        public async Task<Toppings>AddTopping(Toppings topping)
        {
            _db.Toppings.Add(topping);
            _db.SaveChanges();
            return topping;
        }

        public async Task<OrderToppings>AddToppingToOrder(Toppings topping, OrderToppings top)
        {
            top.Topping = topping;
            top.ToppingId = topping.id;
            _db.Toppings.Add(topping);
            _db.OrderToppings.Add(top);
            _db.SaveChanges();

            return top;
        }

        public async Task<Product> GetProductById(int id)
        {
            return _db.Products.Where(x => x.Id == id).FirstOrDefault()!;
        }

        public async Task<Toppings> GetToppingsById(int id)
        {
            return _db.Toppings.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
