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
                    db.Add(new Customer() { Name = "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    db.Add(new Customer() { Name = "Martin" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 10 });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 10 });
                    db.Add(new Pizza() { Name = "Vegan Supreme", Price = 11});
                    await db.SaveChangesAsync();

                }
                if(!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 2, CreatedAt = new DateTime(2025, 1, 27, 12, 0, 0, DateTimeKind.Utc), Status = OrderStatus.Preparing });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 1, CreatedAt = new DateTime(2025, 1, 27, 12, 0, 0, DateTimeKind.Utc), Status = OrderStatus.Preparing });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, CreatedAt = new DateTime(2025, 1, 26, 12, 0, 0, DateTimeKind.Utc), Status = OrderStatus.Delivered });
                    await db.SaveChangesAsync();
                }
                if(!db.Toppings.Any())
                {
                    db.Add(new Toppings() { Name = "Mushrooms"});
                    db.Add(new Toppings() { Name = "Onions" });
                    db.Add(new Toppings() { Name = "Green Peppers" });
                    db.Add(new Toppings() { Name = "Pineapple" });
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
