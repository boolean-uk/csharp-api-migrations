using exercise.pizzashopapi.Models;
using System.Drawing.Text;

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
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" , Price = 6});
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 5 });
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
