using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public static void SeedPizzaShopApi(this WebApplication app)
        {
            using (var db = new DataContext())
            {
                if (!db.Customers.Any())
                {
                    db.Add(new Customer() { Name = "Nigel", Address = "Why do java programmers wear glasses?" });
                    db.Add(new Customer() { Name = "avadakedavrO", Address = "Because they dont C#" });
                    db.Add(new Customer() { Name = "Dave", Address = "Ba dum tsss" });
                    db.SaveChanges();
                }
                if (!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 12.99M });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 13.99M });
                    db.Add(new Pizza() { Name = "MacVoldemort", Price = 14.99M });
                    db.SaveChanges();
                }

                if (!db.Orders.Any())
                {
                    var nigel = db.Customers.FirstOrDefault(c => c.Name == "Nigel");
                    var dave = db.Customers.FirstOrDefault(c => c.Name == "Dave");
                    var avadakedavrO = db.Customers.FirstOrDefault(c => c.Name == "avadakedavrO");
                    var cheesePizza = db.Pizzas.FirstOrDefault(p => p.Name == "Cheese & Pineapple" && p.Price == 12.99M);
                    var veganPizza = db.Pizzas.FirstOrDefault(p => p.Name == "Vegan Cheese Tastic" && p.Price == 13.99M);
                    var macVoldemortPizza = db.Pizzas.FirstOrDefault(p => p.Name == "MacVoldemort" && p.Price == 14.99M);
                    db.Add(new Order() { CustomerId = dave.Id, PizzaId = cheesePizza.Id, OrderDate = DateTime.Now });
                    db.Add(new Order() { CustomerId = nigel.Id, PizzaId = veganPizza.Id, OrderDate = DateTime.Now });
                    db.Add(new Order() { CustomerId = avadakedavrO.Id, PizzaId = macVoldemortPizza.Id, OrderDate = DateTime.Now });

                    db.SaveChanges();
                }
            }
        }
    }
}
