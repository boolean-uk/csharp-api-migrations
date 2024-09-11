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
                    db.Add(new Customer() { Name = "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    db.Add(new Customer() { Name = "Toni" });
                    db.SaveChanges();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 60 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 60 });
                    db.Add(new Pizza() { Name = "Pepperoni", Price = 50 });
                    await db.SaveChangesAsync();

                }
                if (!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 2, Status = (PizzaStatus) 5 });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 1, Status = (PizzaStatus) 4 });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, Status = (PizzaStatus) 2 });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
