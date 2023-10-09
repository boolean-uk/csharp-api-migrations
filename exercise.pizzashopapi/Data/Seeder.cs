using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer() { Name = "Dave", Address = "London" },
            new Customer() { Name = "Nigel", Address = "London" },
            new Customer() { Name = "Konstantina", Address = "Greece" }
        };

        private static List<Pizza> _pizzas = new List<Pizza>()
        {
            new Pizza() { Name = "Cheese & Pineapple", Price = 13.99M },
            new Pizza() { Name = "Vegan Cheese Tastic", Price = 15.50M },
            new Pizza() { Name = "BBQ Chicken", Price = 12.80M }
        };

        private static List<Order> _orders = new List<Order>()
        {
            new Order() {
                OrderDate = DateTime.Now,
                CustomerId = _customers[0].Id,
                Customer = _customers[0],
                PizzaId = _pizzas[0].Id,
                Pizza = _pizzas[0]
            },
            new Order() {
                OrderDate = DateTime.Now,
                CustomerId = _customers[1].Id,
                Customer = _customers[1],
                PizzaId = _pizzas[1].Id,
                Pizza = _pizzas[1]
            },
            new Order() {
                OrderDate = DateTime.Now,
                CustomerId = _customers[2].Id,
                Customer = _customers[2],
                PizzaId = _pizzas[2].Id,
                Pizza = _pizzas[2]
            }
        };

        public static void SeedPizzaShopApi(this WebApplication app)
        {
            using(var db = new DataContext())
            {
                if(!db.Customers.Any())
                {
                    db.AddRange(_customers);
                    db.SaveChanges();
                }
                if(!db.Pizzas.Any())
                {
                    db.AddRange(_pizzas);
                    db.SaveChanges();
                }

                //order data
                if(!db.Orders.Any())
                {
                    db.AddRange(_orders);
                    db.SaveChanges();
                }
            }
        }
    }
}
