﻿using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using(var db = new DatabaseContext())
            {
                if(!db.Customers.Any())
                {
                    db.Add(new Customer() { Name="Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    db.Add(new Customer() { Name = "Jone" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 12.34m });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 23.45m });
                    db.Add(new Pizza() { Name = "Pepperoni", Price = 34.56m});
                    await db.SaveChangesAsync();

                }
                if(!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 2 });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 1 });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3 });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
