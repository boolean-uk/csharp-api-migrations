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
                    db.Add(new Customer() { Id = 1, Name = "Nigel" });
                    db.Add(new Customer() { Id = 2, Name = "Dave" });
                    db.Add(new Customer() { Id = 3, Name = "Dennis" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Id = 1, Name = "Cheese & Pineapple", Price = 50 });
                    db.Add(new Pizza() { Id = 2, Name = "Vegan Cheese Tastic", Price = 70 });
                    db.Add(new Pizza() { Id = 3, Name = "Dobbel Pepperoni", Price = 100 });
                    await db.SaveChangesAsync();

                }

                //order data
                if(!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1, OrderTime = DateTime.UtcNow, Status = "Preparing" });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 2, OrderTime = DateTime.UtcNow + TimeSpan.FromMinutes(4), Status = "Delivering" });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, OrderTime = DateTime.UtcNow + TimeSpan.FromMinutes(20), Status = "Delivered"});

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
