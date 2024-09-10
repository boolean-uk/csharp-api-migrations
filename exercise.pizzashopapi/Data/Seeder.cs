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
                    db.Add(new Customer() { Name= "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    db.Add(new Customer() { Name = "Agron" });
                    db.SaveChanges();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" });
                    db.Add(new Pizza() { Name = "Al Tono" });
                    await db.SaveChangesAsync();
                }

                //order data
                if(1==1)
                {

                    db.SaveChanges();
                }
            }
        }
    }
}
