using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static Task SeedPizzaShopApi(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DataContext>();

            if (!db.Customers.Any())
            {
                db.Add(new Customer() { Name = "Nigel" });
                db.Add(new Customer() { Name = "Dave" });
                db.Add(new Customer() { Name = "Petter" });
                await db.SaveChangesAsync();
            }

            if (!db.Pizzas.Any())
            {
                db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 95 });
                db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 90 });
                db.Add(new Pizza() { Name = "Diavola", Price = 100 });
                await db.SaveChangesAsync();
            }

            if (!db.Products.Any())
            {
                db.Add(new Product() { Name = "Burger", Price = 110 });
                db.Add(new Product() { Name = "Drink", Price = 20 });
                db.Add(new Product() { Name = "Fries", Price = 40 });
                await db.SaveChangesAsync();
            }

            if (!db.Toppings.Any())
            {
                db.Add(new Topping() { Name = "Beef", Price = 20 });
                db.Add(new Topping() { Name = "Onion", Price = 5 });
                db.Add(new Topping() { Name = "Fish", Price = 40 });
                await db.SaveChangesAsync();
            }
        }
    }
}
