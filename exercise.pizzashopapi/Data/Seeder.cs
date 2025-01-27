using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

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
                    db.Customers.Add(new Customer() { Name="Nigel" });
                    db.Customers.Add(new Customer() { Name = "Dave" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Pizzas.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Pizzas.Add(new Pizza() { Name = "Vegan Cheese Tastic" });
                    await db.SaveChangesAsync();

                }

                //order data
                if(!db.Orders.Any())
                {
                    db.Orders.Add(new Order() { CustomerId=1, PizzaId=1 });
                    db.Orders.Add(new Order() { CustomerId=2, PizzaId=2 });
                    await db.SaveChangesAsync();
                }

                if (!db.Toppings.Any())
                {
                    db.Toppings.Add(new Topping() { Name = "Garlic", Price = 0.12m });
                    await db.SaveChangesAsync();
                }

                if (!db.OrderToppings.Any())
                {
                    db.OrderToppings.Add(new OrderToppings() { OrderId = 1, ToppingId = 1 });
                    await db.SaveChangesAsync();
                }

                if (!db.DeliveryDrivers.Any())
                {
                    db.DeliveryDrivers.Add(new DeliveryDriver() { Name = "Vilgot" });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
