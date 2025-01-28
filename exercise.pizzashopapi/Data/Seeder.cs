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
                    db.Add(new Customer() { Id = 3, Name = "Magnus" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Id = 1, Name = "Cheese & Pineapple", Price = 9.99m });
                    db.Add(new Pizza() { Id = 2, Name = "Vegan Cheese Tastic", Price = 12.99m });
                    db.Add(new Pizza() { Id = 3, Name = "Mighty Meat", Price = 14.99m });
                    await db.SaveChangesAsync();
                }
                
                if (!db.Toppings.Any())
                {
                    db.Add(new Topping() { Id = 1, Name = "Bacon" });
                    db.Add(new Topping() { Id = 2, Name = "Mushrooms" });
                    db.Add(new Topping() { Id = 3, Name = "Olives" });
                    await db.SaveChangesAsync();
                }

                if(!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1, OrderDate = DateTime.Parse("2021-01-01").ToUniversalTime() });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 2, OrderDate = DateTime.Parse("2021-01-01").ToUniversalTime() });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, OrderDate = DateTime.Parse("2025-01-27").ToUniversalTime() });
                    
                    await db.SaveChangesAsync();
                    
                    // Toppings for testing
                    var order = db.Orders.Find(2);
                    order.Toppings.Add(new Topping() { Id = 1, Name = "Bacon" });
                    order.Toppings.Add(new Topping() { Id = 2, Name = "Mushrooms" });
                    
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
