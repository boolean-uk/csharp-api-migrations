using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using (var db = new DataContext())
            {
                if (!db.Customers.Any())
                {
                    db.Add(new Customer() { Name = "Dave" });
                    db.Add(new Customer() { Name = "Nigel" });
                    db.Add(new Customer() { Name = "Andreas" });
                    await db.SaveChangesAsync();
                }
                if (!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 10 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 15 });
                    db.Add(new Pizza() { Name = "Mushrooms & Onion", Price = 8 });
                    await db.SaveChangesAsync();

                }
                if (!db.DeliveryDrivers.Any())
                {
                    db.Add(new DeliveryDriver() { Name = "Donald Driver" });
                    db.Add(new DeliveryDriver() { Name = "Daisy Driver" });
                    db.Add(new DeliveryDriver() { Name = "Daffy Driver" });
                    db.Add(new DeliveryDriver() { Name = "Dennis Driver" });
                    await db.SaveChangesAsync();
                }

                //order data
                if (!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1, OrderedAt = new DateTime(2025, 1, 20, 8, 30, 0, DateTimeKind.Utc), Price = 10,DeliveryDriverId = 1 });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 2, OrderedAt = new DateTime(2025, 1, 23, 19, 10, 0, DateTimeKind.Utc), Price = 15, DeliveryDriverId = 2 });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, OrderedAt = new DateTime(2025, 1, 26, 16, 45, 0, DateTimeKind.Utc), Price = 8, DeliveryDriverId = 3 });
                    await db.SaveChangesAsync();
                }

                if (!db.Toppings.Any())
                {
                    db.Add(new Topping() { Name = "Bacon", Price = 3 });
                    db.Add(new Topping() { Name = "Pineapple", Price = 2 });
                    db.Add(new Topping() { Name = "Vegan Cheese", Price = 1 });
                    db.Add(new Topping() { Name = "Mushrooms", Price = 1 });
                    db.Add(new Topping() { Name = "Onion", Price = 1 });
                    await db.SaveChangesAsync();
                }

                if (!db.OrderToppings.Any())
                {
                    db.Add(new OrderToppings() { OrderId = 1, ToppingId = 2 });
                    db.Add(new OrderToppings() { OrderId = 2, ToppingId = 3 });
                    db.Add(new OrderToppings() { OrderId = 3, ToppingId = 4 });
                    db.Add(new OrderToppings() { OrderId = 3, ToppingId = 5 });
                    await db.SaveChangesAsync();
                }

                
            }
        }
    }
}
