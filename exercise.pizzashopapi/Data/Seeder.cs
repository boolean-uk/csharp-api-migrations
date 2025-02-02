using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using (var db = new DataContext())
            {
                // Seed Customers
                if(!db.Customers.Any())
                {
                    db.Add(new Customer() { Name = "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    await db.SaveChangesAsync();
                }

                // Seed Pizzas
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 150 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 120 });
                    await db.SaveChangesAsync();
                }

                // Seed Toppings
                if(!db.Toppings.Any())
                {
                    db.Add(new Toppings() { Type = "Cheese" });
                    db.Add(new Toppings() { Type = "Pineapple" });
                    await db.SaveChangesAsync();
                }

                // Seed Orders
                if(!db.Orders.Any())
                {
                    db.Add(new Order()
                    {
                        Id = 1,
                        CustomerId = 1,
                        PizzaId = 1,
                        OrderToppings = new List<OrderTopping> { new OrderTopping { ToppingId = 2 } },
                        OrderStatus = {"Baking"}
                    });

                    db.Add(new Order()
                    {
                        Id = 2,
                        CustomerId = 2,
                        PizzaId = 2,
                        OrderToppings = new List<OrderTopping> { new OrderTopping { ToppingId = 1 } },
                        OrderStatus = { "Preparing" }
                    });

                    await db.SaveChangesAsync();
                }

                // Seed Order Toppings (Many-to-Many Relationship)
                if(!db.OrderToppings.Any())
                {
                    db.Add(new OrderTopping() { Id = 1, OrderId = 1, ToppingId = 1 });
                    db.Add(new OrderTopping() { Id = 2, OrderId = 2, ToppingId = 2 });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
