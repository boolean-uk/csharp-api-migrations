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
                    db.Add(new Customer() { Name = "Lowe" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" , Price = 8.5m });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" , Price = 8.5m });
                    db.Add(new Pizza() { Name = "Super Kebab" , Price = 8.5m });
                    await db.SaveChangesAsync();

                }

                // topping data
                if(!db.Toppings.Any())
                {
                    
                    db.Add(new Topping() { Name = "Lettuce",  Price = 0.25m });
                    db.Add(new Topping() { Name = "Cucumber", Price = 0.25m});
                    db.Add(new Topping() { Name = "Carrot",   Price = 0.25m });
                    await db.SaveChangesAsync();
                }


                //order data
                if(!db.Orders.Any())
                {
                    
                    db.Add(new Order() { CustomerId = 1, PizzaId = 3, startTime = (DateTime.Now.AddMinutes(-2)).ToUniversalTime() });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 1, startTime = (DateTime.Now.AddMinutes(-3)).ToUniversalTime() });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 2, startTime = (DateTime.Now.AddMinutes(-14)).ToUniversalTime() });
                    await db.SaveChangesAsync();
                }

                // OrderToppings data
                if (!db.OrderToppings.Any())
                {
                    db.Add(new OrderToppings() { OrderId=1, ToppingId = 1, Amount = 1 });
                    db.Add(new OrderToppings() { OrderId=2, ToppingId = 2, Amount = 1 });
                    db.Add(new OrderToppings() { OrderId=3, ToppingId = 3, Amount = 1 });
                    db.Add(new OrderToppings() { OrderId=3, ToppingId = 2, Amount = 1 });
                    await db.SaveChangesAsync();
                }
                
            }
        }
    }
}
