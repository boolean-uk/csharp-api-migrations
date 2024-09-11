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
                    //List<Customer> customers = new 
                    db.Customers.Add(new Customer() { Name="Nigel" });
                    db.Customers.Add(new Customer() { Name = "Dave" });
                    db.Customers.Add(new Customer() { Name = "Daniel"});
                    db.SaveChanges();
                }
                if(!db.Pizzas.Any())
                {
                    db.Pizzas.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 1.75m });
                    db.Pizzas.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 2.25m});
                    db.Pizzas.Add(new Pizza() { Name = "Spicy Chicken", Price = 1.99m});
                    await db.SaveChangesAsync();

                }

                if (!db.Orders.Any())
                {
                    db.Orders.Add(new Order() { CustomerId = 1, PizzaId = 1, ReceivedAt = DateTime.UtcNow });
                    db.Orders.Add(new Order() { CustomerId = 2, PizzaId = 2, ReceivedAt = DateTime.UtcNow });
                    db.Orders.Add(new Order() { CustomerId = 3, PizzaId = 3, ReceivedAt = DateTime.UtcNow });
                }

                //order data
                if(1==1)
                {
                    db.SaveChanges();
                }
            }
        }
    }
}
