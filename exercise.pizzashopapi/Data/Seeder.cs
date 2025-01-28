using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public static async void SeedPizzaShopApi(this WebApplication app)
        {
            using (var db = new DataContext())
            {
                if (!db.Customers.Any())
                {
                    db.Add(new Customer() { Name = "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    await db.SaveChangesAsync();
                }
                if (!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" });
                    await db.SaveChangesAsync();
                }
                if (!db.DeliveryDrivers.Any())
                {
                    db.DeliveryDrivers.Add(new DeliveryDriver() { Name = "Driver 1" });
                    db.DeliveryDrivers.Add(new DeliveryDriver() { Name = "Driver 2" });
                    await db.SaveChangesAsync();
                }
                if (!db.Orders.Any())
                {
                    db.Orders.Add(
                        new Order()
                        {
                            CustomerId = 1,
                            PizzaId = 1,
                            DeliveryDriverId = 1,
                        }
                    );
                    await db.SaveChangesAsync();
                }

                if (!db.Toppings.Any())
                {
                    db.Toppings.Add(new Topping() { Name = "Pineapple" });
                    db.Toppings.Add(new Topping() { Name = "Bacon" });
                    await db.SaveChangesAsync();
                }

                if (!db.OrderToppings.Any())
                {
                    db.OrderToppings.Add(new OrderToppings() { OrderId = 1, ToppingId = 1 });
                    await db.SaveChangesAsync();
                }

                //order data
                if (1 == 1)
                {
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
