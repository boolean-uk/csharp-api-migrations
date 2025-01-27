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
                    db.Add(new Customer() { Name = "Giar" });

                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 20 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 15 });
                    db.Add(new Pizza() { Name = "Cheese & Chicken", Price = 15 });

                    await db.SaveChangesAsync();

                }

                //order data
                if (!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1, Date = DateTime.Now });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 2, Date = DateTime.Now });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, Date = DateTime.Now });
                    await db.SaveChangesAsync();
                }
                //topping data
                if (!db.Toppings.Any())
                {
                    db.Add(new PizzaTopping() { Name = "Pepperoni", Price = 2 });
                    db.Add(new PizzaTopping() { Name = "Bacon", Price = 4 });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
