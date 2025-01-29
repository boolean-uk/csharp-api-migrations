# C# Migrations Exercise

## Pizza Shop Api

Pizza Shop needs a very simple ordering system with just just 3 tables, Customer, Pizza and Order.

## Setup
- Create, then add your credentials to the appsettings.json file and connect to your [neon](https://neon.tech) database.  

## Core

- Write all endpoints in the PizzaShopApi.cs
- Use your initiative to create relevant endpoints such as GetOrders, GetOrdersByCustomerId, GetPizzas etc..
- Use Dependency Injection to instance the DbContext Retoppository
- Inject the IRepository into the EndPoints in the PizzaShopApi
- An order consists of 1 customer ordering 1 pizza.
- Seed some data for the orders. Dave likes a Cheese & Pineapple pizza and Nigel likes Vegan ones.  
- Include yourself as a customer and your favourite Pizza.


## Extension (choose at least two)

- Add extra toppings to Pizzas and allow customers to add toppings to their order.  Add a new table for Toppings and a new table for OrderToppings.  Add any endpoints you think necessary to add toppings.
- Assume that Pizzas take 3 minutes to prepare and 12 minutes to cook in the oven. Modify your code so your customers see at what stage their order is and add an endpoint so the delivery drivers app can set the order as Delivered
- The Pizza Shop can only cook 4 pizzas at a time and the delivery driver is allocated 10 minutes to deliver one pizza at a time.  Add an estimated delivery time to the Order!
- Add a new table for DeliveryDrivers and add an endpoint to assign a driver to an order.  Add a new endpoint to get all orders for a driver.
- Add the ability for the Pizza shop to sell other products on the Menu. e.g. Burgers, Fries, Drinks.  Update any existing code and add any endpoints you think necessary to add products these to an order.



```
