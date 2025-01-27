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
                    db.Add(new Customer() { Id = 1, Name="Nigel" });
                    db.Add(new Customer() { Id = 2, Name = "Dave" });
                    db.Add(new Customer() { Id = 3, Name = "Axel" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza()
                    {
                        Id = 1,
                        Name = "Cheese & Pineapple",
                        Price = 10,
                        
                    });
                    db.Add(new Pizza() { Id = 2, Name = "Vegan Cheese Tastic" , Price = 20 });
                    db.Add(new Pizza() { Id = 3, Name = "Kebab Pizza", Price = 15 });
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


                }

                //order data
                if (!db.Orders.Any())
                {
                    db.Add(new Order()
                    {
                        pizzaId = 1,
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
                        pizzaId = 3,
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
                        pizzaId = 2,
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


                    await db.SaveChangesAsync();
                }

               
            }
        }
    }
}
