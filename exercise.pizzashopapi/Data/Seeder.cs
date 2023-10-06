using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public static void SeedPizzaShopApi(this WebApplication app)
        {
            using(var db = new DataContext())
            {
                if(!db.Customers.Any())
                {
                    db.Add(new Customer() { Name= "Nigel", Address="Milkyway" });
                    db.Add(new Customer() { Name = "Dave", Address= "Mars" });
                    db.Add(new Customer() { Name = "Annefleur", Address= "Mountains" });
                    db.SaveChanges();
                }
                if (!db.Pizzas.Any()) { 
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" });
                    db.Add(new Pizza() { Name = "Peperoni and red onion" });
                    db.SaveChanges();

                }
                if(!db.Orders.Any())
                {
                    db.Add(new Order() { OrderDate = DateTime.UtcNow, CustomerId = 2, PizzaId = 1 });
                    db.Add(new Order() { OrderDate = DateTime.UtcNow, CustomerId = 3, PizzaId = 2 });
                    db.Add(new Order() { OrderDate = DateTime.UtcNow, CustomerId = 4, PizzaId = 3 });
                    db.SaveChanges();

                }
            //order data
           
            }
        }
    }
}
