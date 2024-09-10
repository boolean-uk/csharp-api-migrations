using exercise.pizzashopapi.Models.Customer;
using exercise.pizzashopapi.Models.Order;
using exercise.pizzashopapi.Models.Pizza;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzas = app.MapGroup("pizzas");
            pizzas.MapGet("/", GetMenu);
            pizzas.MapGet("/{id}", GetMenuItem);
            pizzas.MapGet("/orders", GetOrders);
            pizzas.MapGet("/orders/{id}", GetOrder);
            pizzas.MapGet("/orders/customer", GetOrdersByCustomer);
            pizzas.MapPost("/pizza/{id}", OrderPizza);
            pizzas.MapPut("/pizza/{id}", UpdateOrder);
            pizzas.MapPost("/pizza/customer/{id}", BecomeCustomer);
                
        }

        private static IResult BecomeCustomer(IRepository repository, string Name)
        {
            return TypedResults.Ok(repository.BecomeCustomer(Name));
        
        
        }

        private static IResult UpdateOrder(IRepository repository, int orderId, int pizzaId)
        {
            return TypedResults.Ok(repository.UpdateOrder(orderId, pizzaId));
        }

        private static IResult OrderPizza(IRepository repository, int pizzaId, int customerId)
        {
            return TypedResults.Ok(repository.OrderPizza(pizzaId, customerId));

        }

        private static IResult GetOrdersByCustomer(IRepository repository, int customerId)
        {
            return TypedResults.Ok(repository.GetOrdersByCustomer(customerId));

        }

        private static IResult GetOrder(IRepository repository, int orderId)
        {
            return TypedResults.Ok(repository.GetOrder(orderId));
        }

        private static IResult GetOrders(IRepository repository)
        {
            return TypedResults.Ok(repository.GetOrders());
        }

        private static IResult GetMenuItem(IRepository repository, int pizzaId)
        {
            return TypedResults.Ok(repository.GetMenuItem(pizzaId));
        }

        private static IResult GetMenu(IRepository repository)
        {
            return TypedResults.Ok(repository.GetMenu());
        }
    }
}
