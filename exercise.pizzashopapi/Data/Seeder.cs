using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using (var db = new DataContext())
            {
                if (!db.Customers.Any())
                {
                    db.Customers.Add(new Customer() { Name = "Nigel" });
                    db.Customers.Add(new Customer() { Name = "Dave" });
                    db.Customers.Add(new Customer() { Name = "Agron" });
                    await db.SaveChangesAsync();
                }

                if (!db.Pizzas.Any())
                {
                    db.Pizzas.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 7.99m });
                    db.Pizzas.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 5.99m });
                    db.Pizzas.Add(new Pizza() { Name = "Al Tono", Price = 9.99m });
                    await db.SaveChangesAsync();
                }

              
                if (!db.Orders.Any())
                {
                    
                    var customerNigel = db.Customers.FirstOrDefault(c => c.Name == "Nigel");
                    var customerDave = db.Customers.FirstOrDefault(c => c.Name == "Dave");
                    var customerAgron = db.Customers.FirstOrDefault(c => c.Name == "Agron");

                    var pizzaCheesePineapple = db.Pizzas.FirstOrDefault(p => p.Name == "Cheese & Pineapple");
                    var pizzaVeganCheese = db.Pizzas.FirstOrDefault(p => p.Name == "Vegan Cheese Tastic");
                    var pizzaAlTono = db.Pizzas.FirstOrDefault(p => p.Name == "Al Tono");

                    
                    if (customerNigel != null && pizzaCheesePineapple != null)
                    {
                        db.Orders.Add(new Order()
                        {
                            Customer = customerNigel,
                            CustomerId = customerNigel.Id,
                            Pizza = pizzaCheesePineapple,
                            PizzaId = pizzaCheesePineapple.Id,
                            OrderDate = DateTime.UtcNow
                        });
                    }

                    if (customerDave != null && pizzaVeganCheese != null)
                    {
                        db.Orders.Add(new Order()
                        {
                            CustomerId = customerDave.Id,
                            Customer = customerDave,
                            Pizza = pizzaVeganCheese,
                            PizzaId = pizzaVeganCheese.Id,
                            OrderDate = DateTime.UtcNow
                        });
                    }

                    if (customerAgron != null && pizzaAlTono != null)
                    {
                        db.Orders.Add(new Order()
                        {
                            CustomerId = customerAgron.Id,
                            Customer = customerAgron,
                            Pizza = pizzaAlTono,
                            PizzaId = pizzaAlTono.Id,
                            OrderDate = DateTime.UtcNow
                        });
                    }

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
