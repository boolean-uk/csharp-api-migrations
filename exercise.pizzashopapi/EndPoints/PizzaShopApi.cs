using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var orderGroup = app.MapGroup("pizza");
            orderGroup.MapGet("/", GetPizzas);
            orderGroup.MapPost("/", NewPizza);

            var anotherGroup = app.MapGroup("orders");
            anotherGroup.MapGet("/", GetOrders);
            anotherGroup.MapGet("/{id}", GetOrdersByCustomerId);
            anotherGroup.MapPost("/", CreateOrder);

            var thirdGroup = app.MapGroup("customers");
            thirdGroup.MapGet("/", GetCustomers);
        }

        private static async Task<IResult> CreateOrder(IRepository repository, Order order)
        {
            var result = await repository.CreateOrder(order);
            return TypedResults.Created($"Pizza with Id number {result.PizzaId} is created");
        }

        private static async Task<IResult> NewPizza(IRepository repository, Pizza pizza)
        {
            var result = await repository.CreatePizza(pizza);
            return TypedResults.Created($"{result.Name} created");
        }

        private static async Task<IResult> GetOrdersByCustomerId(IRepository repository,int id)
        {
            var result = await repository.GetOrdersByCustomerId(id);
            return TypedResults.Ok(result);
        }

        private static async Task<IResult> GetCustomers(IRepository repository)
        {
            var result = await repository.GetCustomers();
            return TypedResults.Ok(result);
        }

        private static async Task<IResult> GetOrders(IRepository repository)
        {
            var result = await repository.GetOrders();
            OrderResponse response = new();

            foreach (var order in result)
            {
                GetOrderDTO orderDTO
            }
            return TypedResults.Ok(result);
        }

        private static async Task<IResult> GetPizzas(IRepository repository)
        {
            var result = await repository.GetPizzas();
            return TypedResults.Ok(result);
        }
  
    }
}
