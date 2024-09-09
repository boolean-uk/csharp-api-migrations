# C# Migrations Exercise

## Pizza Shop Api

Pizza Shop needs a very simple ordering system with just just 3 tables, Customer, Pizza and Order.

## Setup
- Create, then add your credentials to the appsettings.json file and connect to your [neon](https://neon.tech) database.  

## Core

- Write all endpoints in the PizzaShopApi.cs
- Use your initiative to create relevant endpoints such as GetOrders, GetOrdersByCustomerId, GetPizzas etc..
- Use Dependency Injection to instance the DbContext Repository
- Inject the IRepository into the EndPoints in the PizzaShopApi
- An order consists of 1 customer ordering 1 pizza.
- Seed some data for the orders. Dave likes a Cheese & Pineapple pizza and Nigel likes Vegan ones.  
- Include yourself as a customer and your favourite Pizza.


## Extension

- Assume that Pizzas take 3 minutes to prepare and 12 minutes to cook in the oven. Modify your code so your customers see at what stage their order is and add an endpoint so the delivery drivers app can set the order as Delivered

## Super Extension (optional)

- The Pizza Shop can only cook 4 pizzas at a time and the delivery driver is allocated 10 minutes to deliver one pizza at a time.  Add an estimated delivery time to the Order!
 

## Tips

- You can map the Pizza to the Customer with the Order model
- You'll need a composite key in the Order model

```cs
 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
        modelBuilder.Entity<Order>().HasKey(o=> new {o.PizzaId, o.CustomerId});
 }


```