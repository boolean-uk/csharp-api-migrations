using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.Data
{
    public class Seeder
    {
        private List<Customer> _customers = [
            new Customer { Id = 1, Name = "Nigel"},
            new Customer { Id = 2, Name = "Dave"},
            new Customer { Id = 3, Name = "Nikolai"}
        ];

        private List<Product> _products = [
            new Product { Id = 1, ProductType = ProductType.Pizza, Name = "Hawaiian Pizza", Price = 200 },
            new Product { Id = 2, ProductType = ProductType.Pizza, Name = "Vegan Cheese Tastic", Price = 165 },
            new Product { Id = 3, ProductType = ProductType.Pizza, Name = "Pizza Vendetta", Price = 210 },
            new Product { Id = 4, ProductType = ProductType.Burger, Name = "Bacon Cheese Burger", Price = 195 },
            new Product { Id = 5, ProductType = ProductType.Fries, Name = "Regular Fries", Price = 110 },
            new Product { Id = 6, ProductType = ProductType.Drinks, Name = "Coca Cola 0.4L", Price = 65 },
            new Product { Id = 7, ProductType = ProductType.Drinks, Name = "Fanta Orange 0.4L", Price = 65 },
        ];

        private List<Order> _orders = [
            new Order { Id = 1, CustomerId = 1, ProductId = 2 },
            new Order { Id = 2, CustomerId = 2, ProductId = 1 },
            new Order { Id = 3, CustomerId = 3, ProductId = 3 },
            new Order { Id = 4, CustomerId = 3, ProductId = 7 },
        ];

        private List<Topping> _toppings = [
            new Topping {Id = 1, Name = "Bacon", Price = 20 },
            new Topping {Id = 2, Name = "Onion Rings", Price = 15 },
            new Topping {Id = 3, Name = "Hot Sauce", Price = 12 },
        ];

        private List<OrderTopping> _orderToppings = [
            new OrderTopping { OrderId = 3, ToppingId = 3 },
            new OrderTopping { OrderId = 1, ToppingId = 1 }
        ];

        public List<Customer> Customers { get { return _customers; } }
        public List<Product> Products { get { return _products; } }
        public List<Order> Orders { get { return _orders; } }
        public List<Topping> Toppings { get { return _toppings; } }
        public List<OrderTopping> OrderToppings { get { return _orderToppings; } }
    }
}
