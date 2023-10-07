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
                    db.Add(new Customer() { Name="Nigel", Address="LondonAve 116" });
                    db.Add(new Customer() { Name = "Dave", Address = "LondonAve 116" });
                    db.Add(new Customer() { Name = "Spiros", Address = "Ermou 150" });
                    db.SaveChanges();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 10 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 10 });
                    db.Add(new Pizza() { Name = "Barbeque Hot Chilli Sauce", Price = 10 });
                    db.SaveChanges();

                }

                //order data
                if (!db.Orders.Any())
                {
                    db.Add(new Order() { OrderDate = "6/10/23", Price = 10, CustomerId = 1, PizzaId = 1 });
                    db.Add(new Order() { OrderDate = "6/10/23", Price = 10, CustomerId = 2, PizzaId = 2 });
                    db.Add(new Order() { OrderDate = "6/10/23", Price = 10, CustomerId = 3, PizzaId = 3 });
                    db.SaveChanges();

                }
            }
        }
    }
}
