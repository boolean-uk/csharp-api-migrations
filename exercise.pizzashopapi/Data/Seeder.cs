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
                    db.Add(new Customer() { Name="Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 20 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 15 });
                    await db.SaveChangesAsync();

                }

                //order data
                if (!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1, Date = DateTime.Now });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 2, Date = DateTime.Now });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
