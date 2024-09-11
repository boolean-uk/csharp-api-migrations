using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public static async void SeedPizzaShopApi(this WebApplication app)
        {
            await using var db = new DataContext();
            if(!db.Customers.Any())
            {
                db.Add(new Customer() { Name="Nigel" });
                db.Add(new Customer() { Name = "Dave" });
                db.Add(new Customer() { Name = "Eyvind" });
                db.Add(new Customer() { Name = "Espen" });
                db.Add(new Customer() { Name = "Silje" });
                db.Add(new Customer() { Name = "Daniel" });
                db.Add(new Customer() { Name = "Øyvind" });
                await db.SaveChangesAsync();
            }
            if(!db.Pizzas.Any())
            {
                db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 189 });
                db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 149 });
                db.Add(new Pizza() { Name = "Even Heavier Heaven", Price = 279 });
                db.Add(new Pizza() { Name = "BBQ", Price = 229 });
                db.Add(new Pizza() { Name = "Italiensk 'Nduja", Price = 179 });
                db.Add(new Pizza() { Name = "Plain Grandiosa", Price = 49 });
                db.Add(new Pizza() { Name = "Hawaii without cheese", Price = 999 });
                await db.SaveChangesAsync();
            }

            //order data
            if(!db.Orders.Any())
            {
                await db.SaveChangesAsync();
            }
        }
    }
}
