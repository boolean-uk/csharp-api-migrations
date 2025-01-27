using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static Task SeedPizzaShopApi(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope()) // Use a scoped service provider
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>(); // Get DataContext from DI

                Console.WriteLine("🔵 Running database seeder...");

                if (!db.Customers.Any())
                {
                    Console.WriteLine("🟢 Seeding Customers...");
                    db.Customers.AddRange(
                        new Customer() { Name = "Nigel" },
                        new Customer() { Name = "Dave" },
                        new Customer() { Name = "Enock" }
                    );
                    await db.SaveChangesAsync();
                }

                if (!db.Pizzas.Any())
                {
                    Console.WriteLine("🟢 Seeding Pizzas...");
                    db.Pizzas.AddRange(
                        new Pizza() { Name = "Cheese & Pineapple", Price = 10.99m },
                        new Pizza() { Name = "Vegan Cheese Tastic", Price = 12.99m },
                        new Pizza() { Name = "Pepperoni Classic", Price = 11.99m }
                    );
                    await db.SaveChangesAsync();
                }

                if (!db.MenuItems.Any())
                {
                    Console.WriteLine("🟢 Seeding Menu Items...");
                    db.MenuItems.AddRange(
                        new MenuItem() { Name = "Burger", Type = "Food", Price = 8.99m },
                        new MenuItem() { Name = "Fries", Type = "Food", Price = 3.99m },
                        new MenuItem() { Name = "Coke", Type = "Drink", Price = 1.99m },
                        new MenuItem() { Name = "Orange Juice", Type = "Drink", Price = 2.49m },
                        new MenuItem() { Name = "Chocolate Milkshake", Type = "Drink", Price = 4.99m }
                    );
                    await db.SaveChangesAsync();
                }

                if (!db.DeliveryDrivers.Any())
                {
                    Console.WriteLine("🟢 Seeding Delivery Drivers...");
                    db.DeliveryDrivers.AddRange(
                        new DeliveryDriver() { Name = "John" },
                        new DeliveryDriver() { Name = "Sarah" }
                    );
                    await db.SaveChangesAsync();
                }

                if (!db.Orders.Any())
                {
                    Console.WriteLine("🟢 Seeding Orders...");

                    var dave = db.Customers.First(c => c.Name == "Dave");
                    var nigel = db.Customers.First(c => c.Name == "Nigel");
                    var you = db.Customers.First(c => c.Name == "Enock");

                    var pineapplePizza = db.Pizzas.First(p => p.Name == "Cheese & Pineapple");
                    var veganPizza = db.Pizzas.First(p => p.Name == "Vegan Cheese Tastic");
                    var pepperoniPizza = db.Pizzas.First(p => p.Name == "Pepperoni Classic");

                    var driverJohn = db.DeliveryDrivers.First(d => d.Name == "John");
                    var driverSarah = db.DeliveryDrivers.First(d => d.Name == "Sarah");

                    db.Orders.AddRange(
                        new Order() { CustomerId = dave.Id, PizzaId = pineapplePizza.Id, OrderDate = DateTime.UtcNow, DeliveryDriverId = driverJohn.Id },
                        new Order() { CustomerId = nigel.Id, PizzaId = veganPizza.Id, OrderDate = DateTime.UtcNow, DeliveryDriverId = driverSarah.Id },
                        new Order() { CustomerId = you.Id, PizzaId = pepperoniPizza.Id, OrderDate = DateTime.UtcNow, DeliveryDriverId = driverJohn.Id }
                    );
                    await db.SaveChangesAsync();
                }

                if (!db.OrderMenuItems.Any())
                {
                    Console.WriteLine("Seeding Order Menu Items...");

                    var orders = db.Orders.ToList();
                    var menuItems = db.MenuItems.ToList();

                    if (orders.Count > 0 && menuItems.Count > 0)
                    {
                        db.OrderMenuItems.AddRange(
                            new OrderMenuItem() { OrderId = orders[0].Id, MenuItemId = menuItems[0].Id, Quantity = new Random().Next(1, 5) }, // Random quantity between 1-4
                            new OrderMenuItem() { OrderId = orders[1].Id, MenuItemId = menuItems[1].Id, Quantity = new Random().Next(1, 5) },
                            new OrderMenuItem() { OrderId = orders[2].Id, MenuItemId = menuItems[2].Id, Quantity = new Random().Next(1, 5) }
                        );

                        await db.SaveChangesAsync();
                    }
                }

                Console.WriteLine("✅ Database seeding complete.");
            }
        }
    }
}
