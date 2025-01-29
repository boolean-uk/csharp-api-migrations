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
                    db.Add(new Customer() { Name = "Jostein" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" });
                    db.Add(new Pizza() { Name = "Pepperoni & Ham" });
                    await db.SaveChangesAsync();

                }

                //order data
                if(!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1 });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 2 });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3 });
                    await db.SaveChangesAsync();
                }

                if(!db.Toppings.Any())
                {
                    db.Add(new Topping() { Name = "Cheese" });
                    db.Add(new Topping() { Name = "Pineapple" });
                    db.Add(new Topping() { Name = "Vegan Cheese" });
                    db.Add(new Topping() { Name = "Pepperoni" });
                    db.Add(new Topping() { Name = "Ham" });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
