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
                    db.Add(new Customer() { Name= "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    db.Add(new Customer() { Name = "Silje" });
                    db.SaveChanges();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 200 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 150 });
                    db.Add(new Pizza() { Name = "Italian Nduja", Price = 180 });
                    await db.SaveChangesAsync();

                }
                if (!db.Orders.Any())
                {
                    db.Orders.Add(new Order() { Id = 1, CustomerId = 1, PizzaId = 1, OrderDate = DateTime.UtcNow });
                    db.Orders.Add(new Order() { Id = 2, CustomerId = 2, PizzaId = 2, OrderDate = DateTime.UtcNow });
                    db.Orders.Add(new Order() { Id = 3, CustomerId = 3, PizzaId = 3, OrderDate = DateTime.UtcNow });
                }
                if (1==1)
                    db.SaveChanges();
            }
        }
    }
}
