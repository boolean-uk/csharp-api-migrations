﻿using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using(var db = new DataContext())
            {
                if(!db.Customers.Any())
                {
                    db.Add(new Customer() { Name="Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tactic" });
                    await db.SaveChangesAsync();

                }
                if(!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 2, Id = 1 });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 1, Id = 2 });
                    await db.SaveChangesAsync();
                }

                //order data
                if(1==1)
                {
                    db.SaveChanges();
                }
            }
        }
    }
}
