using exercise.pizzashopapi.Models;

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
                    await db.AddAsync(new Customer() { Name="Nigel" });
                    await db.AddAsync(new Customer() { Name = "Dave" });
                    await db.AddAsync(new Customer() { Name = "Espen" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    await db.AddAsync(new Pizza() { Name = "Cheese & Pineapple" });
                    await db.AddAsync(new Pizza() { Name = "Vegan Cheese Tastic" });
                    await db.AddAsync(new Pizza() { Name = "BBQ", Price = 250 });
                    await db.SaveChangesAsync();
                    
                }

                //order data
                if(!db.Orders.Any())
                {
                    await db.AddAsync(new Order() { Id = 1, CustomerId = 1, PizzaId = 2, Pickup = DateTime.UtcNow.AddMinutes(15), Stage = "Preparing" });
                    await db.AddAsync(new Order() { Id = 2, CustomerId = 2, PizzaId = 1, Pickup = DateTime.UtcNow.AddMinutes(15), Stage = "Preparing" });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
