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
                    db.Add(new Customer() {Id = 1, Name="Nigel" });
                    db.Add(new Customer() {Id = 2, Name = "Dave" });
                    db.Add(new Customer() {Id = 3, Name = "Kristoffer" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() {Id = 1, Name = "Cheese & Pineapple" , Price = 190m });
                    db.Add(new Pizza() {Id = 2, Name = "Vegan Cheese Tastic", Price = 200m });
                    db.Add(new Pizza() {Id = 3, Name = "Nduja", Price = 210m });
                    await db.SaveChangesAsync();

                }

                
                if(!db.Orders.Any())
                {
                    db.Add(new Order() { Id = 1, CustomerId = 1, PizzaId = 1 });
                    db.Add(new Order() { Id = 2, CustomerId = 2, PizzaId = 2 });
                    db.Add(new Order() { Id = 3, CustomerId = 3, PizzaId = 3 });



                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
