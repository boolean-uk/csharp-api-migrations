using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static void SeedProductShopApi(this WebApplication app)
        {
            using(var db = new DataContext())
            {
                if(!db.Customers.Any())
                {
                    db.Add(new Customer() { Id = 1, Name="Nigel" });
                    db.Add(new Customer() { Id = 2, Name = "Dave" });
                    db.Add(new Customer() { Id = 3, Name = "Axel" });
                    await db.SaveChangesAsync();
                }
                if(!db.Products.Any())
                {
                    db.Add(new Product()
                    {
                        Id = 1,
                        Type = "Pizza",
                        Name = "Cheese & Pineapple",
                        Price = 10,
                        
                    });
                    db.Add(new Product() { Id = 2, Type = "Pizza", Name = "Vegan Cheese Tastic" , Price = 20 });
                    db.Add(new Product() { Id = 3, Type = "Pizza", Name = "Kebab Pizza", Price = 15 });
                    db.Add(new Product() { Id = 4, Type = "Burger", Name = "Whopper Cheese", Price=15 });
                    await db.SaveChangesAsync();

                }

                if (!db.Toppings.Any())
                {
                    db.Add(new Toppings()
                    {
                        name = "meat",
                        id = 1,
                        cost = 4
                    });

                    db.Add(new Toppings()
                    {
                        name = "gold",
                        id = 2,
                        cost = 40
                    });

                    db.Add(new Toppings()
                    {
                        name = "truffle",
                        id = 3,
                        cost = 15
                    });
                    db.Add(new Toppings()
                    {
                        name = "BBQ sauce",
                        id = 4,
                        cost = 2
                    });


                }

                //order data
                if (!db.Orders.Any())
                {
                    db.Add(new Order()
                    {
                        productId = 1,
                        customerId = 2,
                        orderId = 1,
                        toppings = new List<OrderToppings>(){
                        new OrderToppings() {
                           
                            ToppingId = 1
                        },
                        new OrderToppings() {
                            
                            ToppingId = 2
                        }
                    }
                    });

                    db.Add(new Order()
                    {
                        productId = 3,
                        customerId = 3,
                        orderId = 2,
                        toppings = new List<OrderToppings>(){
                        new OrderToppings() {
                            
                            ToppingId = 1
                        },
                        new OrderToppings() {
                            
                            ToppingId = 3
                        }
                    }
                    });

                    db.Add(new Order()
                    {
                        productId = 2,
                        customerId = 1,
                        orderId = 3,
                        toppings = new List<OrderToppings>(){
                        new OrderToppings() {

                            ToppingId = 1
                        },
                        new OrderToppings() {

                            ToppingId = 2
                        }
                    }
                    });
                        db.Add(new Order()
                        {
                            productId = 4,
                            customerId = 1,
                            orderId = 4,
                            toppings = new List<OrderToppings>(){
                        new OrderToppings() {

                            ToppingId = 1
                        },
                        new OrderToppings() {

                            ToppingId = 4
                        }
                    }
                        });


                    await db.SaveChangesAsync();
                }

               
            }
        }
    }
}
