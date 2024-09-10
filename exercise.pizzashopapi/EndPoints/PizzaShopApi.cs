using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var customers = app.MapGroup("/customers");
            var pizzas = app.MapGroup("/pizzas");
            var orders = app.MapGroup("/orders");

            customers.MapGet("/", GetCustomers);
            customers.MapGet("/{id}", GetACustomer);
            customers.MapPost("/", AddCustomer);
            customers.MapPut("/{id}", EditCustomer);
            customers.MapDelete("/{id}", DeleteCustomer);

            pizzas.MapGet("/", GetPizzas);
            pizzas.MapGet("/{id}", GetAPizza);
            pizzas.MapPost("/", AddPizza);
            pizzas.MapPut("/{id}", EditPizza);
            pizzas.MapDelete("/{id}", DeletePizza);

            orders.MapGet("/", GetOrders);
            orders.MapGet("/{id}", GetAnOrder);
            orders.MapPost("/", AddOrder);
            orders.MapPut("/{id}", EditOrder);
            orders.MapDelete("/{id}", DeleteOrder);
        }

        private static async Task<IResult> DeleteOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> EditOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> AddOrder(IRepository repository, int pizzaId, int customerId)
        {
            return TypedResults.Ok(await repository.AddOrder(pizzaId, customerId));
        }

        private static async Task<IResult> GetAnOrder(IRepository repository, int pizzaId, int customerId)
        {
            return TypedResults.Ok(await repository.GetAnOrder(pizzaId, customerId));
        }

        private static async Task<IResult> GetOrders(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetOrders());
        }

        private static async Task<IResult> DeletePizza(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> EditPizza(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> AddPizza(IRepository repository, int id, string name, int price)
        {
            return TypedResults.Ok(await repository.AddPizza(id, name, price));
        }

        private static async Task<IResult> GetAPizza(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAPizza(id));
        }

        private static async Task<IResult> GetPizzas(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPizzas());
        }

        private static async Task<IResult> DeleteCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> EditCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task<IResult> AddCustomer(IRepository repository, int id, string name)
        {
            return TypedResults.Ok(await repository.AddCusomer(id, name));
        }

        private static async Task<IResult> GetACustomer(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetACusomer(id));
        }

        private static async Task<IResult> GetCustomers(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetCusomers());
        }
    }
}
