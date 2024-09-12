using exercise.pizzashopapi.Models;
using System.Numerics;

namespace exercise.pizzashopapi.Data
{
    public class Seeder
    {
        private List<Pizza> _pizzas = new List<Pizza>();
        private List<Customer> _customers = new List<Customer>();
        private List<Order> _orders = new List<Order>();

        public Seeder()
        {
            if (!_customers.Any())
            {
                _customers.Add(new Customer() { Id = 1, Name = "Nigel" });
                _customers.Add(new Customer() { Id = 2, Name = "Dave" });
                _customers.Add(new Customer() { Id = 3, Name = "Jonas" });
            }

            DateTime now = DateTime.UtcNow;
            TimeSpan timeDifference = TimeSpan.FromMinutes(10);

            if (!_pizzas.Any())
            {
                _pizzas.Add(new Pizza() { Id = 1, Name = "Cheese & Pineapple", Price = 10, CreatedAt = now });
                _pizzas.Add(new Pizza() { Id = 2, Name = "Vegan Cheese Tastic", Price = 20, CreatedAt = now - timeDifference });
                _pizzas.Add(new Pizza() { Id = 3, Name = "Spicy bbq chicken", Price = 50, CreatedAt = now - 2 * timeDifference });
            }

            if (!_orders.Any())
            {
                _orders.Add(new Order() { CustomerId = 1, PizzaId = 1, Delivered = false, CreatedAt = now });
                _orders.Add(new Order() { CustomerId = 2, PizzaId = 2, Delivered = false, CreatedAt = now - timeDifference });
                _orders.Add(new Order() { CustomerId = 3, PizzaId = 3, Delivered = false, CreatedAt = now - 2 * timeDifference });
            }
        }

        public List<Pizza> Pizzas { get { return _pizzas; } }
        public List<Customer> Customers { get { return _customers; } }
        public List<Order> Orders { get {return _orders; } }
    }
}
