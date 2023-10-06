# C# Migrations Exercise

## Pizza Shop Api

Pizza Shop needs a very simple ordering system with just just 3 tables:

-Customer 
-Pizza  
-Order  

```
-Add an appsettings.json file and connect to your database.  
-Run a migration to create the Customer / Pizza tables
-Add an address to the Customer object then run another migration 
-Complete the Order model with an Id, OrderDate and a foreign key to the Customer and Pizza (and include a Pizza/Customer property).  A single order only has 1 customer ordering 1 pizza.
-Run another migration to add the latest updates to the database
-Seed some data for the orders... Dave likes a Cheese & Pineapple pizza and Nigel likes Vegan ones.
-Complete the only method in the Repository to GetOrders() being sure to include the customer and pizza in the results.
```

Try and complete this exercise with at least 3 migrations
