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
                    db.Add(new Customer() { Name="Nigel", Address="Booleanstreet 123" });
                   
                    db.Add(new Customer() { Name = "Dave", Address = "Booleanstreet 321" });

                    db.Add(new Customer() { Name = "Max", Address = "Experisstreet 123" });

                    db.SaveChanges();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price=9m });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 8m });
                    db.Add(new Pizza() { Name = "Quatro Formaggi" , Price = 10m });
                    db.SaveChanges();

                }

                if(!db.Orders.Any())
                {
                    db.Add(new Order() { OrderDate = "19:30", CustomerId=1, PizzaId=1});
                    db.Add(new Order() { OrderDate = "19:00", CustomerId = 2, PizzaId = 2 });
                    db.Add(new Order() { OrderDate = "18:30", CustomerId = 3, PizzaId = 3 });
                    db.SaveChanges();
                }

                
                if (1==1) 
                {
                    db.SaveChanges();
                }

               
                
            }
        }
    }
}
