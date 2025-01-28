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
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" });
                    await db.SaveChangesAsync();

                }
                if (!db.Orders.Any())
                {
                    db.Add(new Order() {  customerId=1, pizzaId=1 });
                    db.Add(new Order() { customerId = 2, pizzaId = 2 });
                    await db.SaveChangesAsync();

                }

                //order data
                if (1==1)
                {

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
