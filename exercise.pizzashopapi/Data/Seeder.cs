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
                    db.Add(new Customer() { Name="Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    db.SaveChanges();
                }

                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" });
                    db.SaveChanges();
                }

                if (!db.Orders.Any())
                {
                    db.Add(new Order() { OrderDate = DateTime.Now, CustomerId = 2, PizzaId = 1 });
                    db.Add(new Order() { OrderDate = DateTime.Now, CustomerId = 1, PizzaId = 2 });
                    db.Add(new Order() { OrderDate = DateTime.Now, CustomerId = 3, PizzaId = 3 });
                    db.SaveChanges();
                }
            }
        }
    }
}