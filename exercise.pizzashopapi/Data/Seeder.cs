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
                    db.Add(new Customer() { Name = "Steven" });

                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 139.99M });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" , Price = 119.99M});
                    db.Add(new Pizza() { Name = "Marshmellow", Price = 89.99M });

                    await db.SaveChangesAsync();

                }
                if (!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 2 });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 1 });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3 });
                    await db.SaveChangesAsync();
                }

                //order data
                if(1==1)
                {

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
