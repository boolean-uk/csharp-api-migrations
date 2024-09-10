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

        private static async Task<IResult> BecomeCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> UpdateOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> OrderPizza(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> GetOrdersByCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> GetOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> GetOrders(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> GetMenuItem(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> GetMenu(IRepository repository)
        {
            throw new NotImplementedException();
        }
    }
}
