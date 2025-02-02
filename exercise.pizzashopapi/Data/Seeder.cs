using exercise.pizzashopapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        private static readonly Random Random = new Random();
        private static readonly List<string> OrderStatuses = new List<string>
            {
                "Preparing", "Baking", "Quality Check", "Out for Delivery", "Delivered"
            };

        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using (var db = new DataContext())
            {
                // Seed Customers
                if (!db.Customers.Any())
                {
                    db.Add(new Customer() { Name = "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    await db.SaveChangesAsync();
                }

                // Seed Pizzas
                if (!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 150 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 120 });
                    await db.SaveChangesAsync();
                }

                // Seed Toppings
                if (!db.Toppings.Any())
                {
                    db.Add(new Toppings() { Type = "Cheese" });
                    db.Add(new Toppings() { Type = "Pineapple" });
                    await db.SaveChangesAsync();
                }

                // Seed Orders
                if (!db.Orders.Any())
                {
                    db.Add(new Order()
                    {
                        Id = 1,
                        CustomerId = 1,
                        PizzaId = 1,
                        OrderToppings = new List<OrderTopping> { new OrderTopping { ToppingId = 2 } },
                        OrderStatus = OrderStatuses[Random.Next(OrderStatuses.Count)]
                    });

                    db.Add(new Order()
                    {
                        Id = 2,
                        CustomerId = 2,
                        PizzaId = 2,
                        OrderToppings = new List<OrderTopping> { new OrderTopping { ToppingId = 1 } },
                        OrderStatus = OrderStatuses[Random.Next(OrderStatuses.Count)]
                    });

                    await db.SaveChangesAsync();
                }


                if (!db.OrderToppings.Any())
                {
                    db.Add(new OrderTopping() { Id = 1, OrderId = 1, ToppingId = 1 });
                    db.Add(new OrderTopping() { Id = 2, OrderId = 2, ToppingId = 2 });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
