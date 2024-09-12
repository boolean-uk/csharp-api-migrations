using exercise.pizzashopapi.Models;
using System.Numerics;

namespace exercise.pizzashopapi.Data
{
    public class Seeder
    {
        private List<Order> _orders = new List<Order>();
        private List<Pizza> _pizzas = new List<Pizza>();
        private List<Customer> _customers = new List<Customer>();

        public List<Order> Orders { get => _orders; }
        public List<Pizza> Pizzas { get => _pizzas; }
        public List<Customer> Customers { get => _customers; }

        public Seeder()
        {
            _customers.Add(new Customer() { Name = "Nigel", Id = 1 });
            _customers.Add(new Customer() { Name = "Dave", Id = 2 });
            _customers.Add(new Customer() { Name = "John", Id = 3 });

            _pizzas.Add(new Pizza() { Name = "Cheese & Pineapple", Id = 1, Price = 8 });
            _pizzas.Add(new Pizza() { Name = "Vegan Cheese Tastic", Id = 2, Price = 2 });
            _pizzas.Add(new Pizza() { Name = "BBQ Chicken", Id = 3, Price = 4 });

            _orders.Add(new Order() { CustomerID = 1, PizzaID = 2});
            _orders.Add(new Order() { CustomerID = 2, PizzaID = 1});
            _orders.Add(new Order() { CustomerID = 3, PizzaID = 3});
        }
    }
}
