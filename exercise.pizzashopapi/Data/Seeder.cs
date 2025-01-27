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
                    db.Add(new Customer() { Id = 1, Name="Nigel" });
                    db.Add(new Customer() { Id = 2, Name = "Dave" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Id = 1, Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Id = 2, Name = "Vegan Cheese Tastic" });
                    await db.SaveChangesAsync();
                }

                if(!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1, OrderDate = DateTime.Parse("2021-01-01").ToUniversalTime() });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 2, OrderDate = DateTime.Parse("2021-01-01").ToUniversalTime() });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
