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
                    db.Add(new Customer() { Name = "Tonnes" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 140});
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 130});
                    db.Add(new Pizza() { Name = "Pepperoni & Pineapple", Price = 150}); 
                    await db.SaveChangesAsync();

                }

                //order data
                if(!db.Orders.Any())
                {
                    db.Add(new Order
                    {
                        CustomerId = 1,
                        PizzaId = 1,
                    });
                    db.Add(new Order
                    {
                        CustomerId = 2,
                        PizzaId = 2,
                    });
                    db.Add(new Order
                    {
                        CustomerId = 2,
                        PizzaId = 2,
                    });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
