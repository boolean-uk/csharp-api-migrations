using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

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
                    db.Add(new Customer() { Name = "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    db.Add(new Customer() { Name = "Bjorg" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 12.5m });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 10.5m });
                    db.Add(new Pizza() { Name = "Squash and Avokado", Price = 12.5m });
                    await db.SaveChangesAsync();

                }

                //order data
                if(!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 2, DeliveryAddress = "England" });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 1, DeliveryAddress = "Also in England, I think" });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, DeliveryAddress = "Lakkegata 53" });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
