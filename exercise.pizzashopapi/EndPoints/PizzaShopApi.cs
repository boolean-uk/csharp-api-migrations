using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints;

public static class PizzaShopApi
{
    public static void ConfigurePizzaShopApi(this WebApplication app)
    {
        app.MapGet("/customers", GetAllCustomers);
        app.MapGet("/customers/{id}", GetCustomer);
        app.MapPost("/customers", CreateCustomer);

        app.MapGet("/drivers", GetAllDrivers);
        app.MapGet("/drivers/{id}", GetDriver);
        app.MapPost("/drivers", CreateDriver);

        app.MapGet("/orders", GetAllOrders);
        app.MapGet("/ordersbycustomer/{id}", GetOrdersByCustomer);
        app.MapGet("/ordersbydriver/{id}", GetOrdersByDriver);
        app.MapPost("/orders", CreateOrder);

        app.MapGet("/pizzas", GetPizzas);
        app.MapPost("/pizzas", CreatePizza);

        app.MapGet("/toppings", GetToppings);
        app.MapPost("/toppings", CreateTopping);
    }

    public static async Task<IResult> GetAllCustomers(IRepository repo)
    {
        var result = await repo.GetCustomers();
        return TypedResults.Ok(result.Select(o => o.ToGetDto()));
    }

    public static async Task<IResult> GetCustomer(IRepository repo, int id)
    {
        var result = await repo.GetCustomer(id);
        return NullableResult(result?.ToGetDto());
    }

    public static async Task<IResult> CreateCustomer(IRepository repo, CustomerPostDto c)
    {
        var result = await repo.CreateCustomer(c);
        return NullableResult(result?.ToGetDto());
    }

    public static async Task<IResult> GetAllDrivers(IRepository repo)
    {
        var result = await repo.GetDeliveryDrivers();
        return TypedResults.Ok(result.Select(o => o.ToGetDto()));
    }

    public static async Task<IResult> GetDriver(IRepository repo, int id)
    {
        var result = await repo.GetDeliveryDriver(id);
        return NullableResult(result?.ToGetDto());
    }

    public static async Task<IResult> CreateDriver(IRepository repo, DeliveryDriverPostDto d)
    {
        var result = await repo.CreateDeliveryDriver(d);
        return NullableResult(result?.ToGetDto());
    }

    public static async Task<IResult> GetAllOrders(IRepository repo)
    {
        var result = await repo.GetOrders();
        return TypedResults.Ok(result.Select(o => o.ToGetDto()));
    }

    public static async Task<IResult> GetOrdersByCustomer(IRepository repo, int id)
    {
        var result = await repo.GetOrdersByCustomer(id);
        return TypedResults.Ok(result.Select(o => o.ToGetDto()));
    }

    public static async Task<IResult> GetOrdersByDriver(IRepository repo, int id)
    {
        var result = await repo.GetOrdersByDriver(id);
        return TypedResults.Ok(result.Select(o => o.ToGetDto()));
    }

    public static async Task<IResult> CreateOrder(IRepository repo, OrderPostDto order)
    {
        var result = await repo.CreateOrder(order);
        return NullableResult(result?.ToGetDto());
    }

    public static async Task<IResult> GetPizzas(IRepository repo)
    {
        var result = await repo.GetPizzas();
        return TypedResults.Ok(result);
    }

    public static async Task<IResult> CreatePizza(IRepository repo, PizzaPostDto pizza)
    {
        var result = await repo.CreatePizza(pizza);
        return NullableResult(result);
    }

    public static async Task<IResult> GetToppings(IRepository repo)
    {
        var result = await repo.GetToppings();
        return TypedResults.Ok(result);
    }

    public static async Task<IResult> CreateTopping(IRepository repo, ToppingDto topping)
    {
        var result = await repo.CreateTopping(topping);
        return NullableResult(result);
    }

    private static IResult NullableResult(object? o)
    {
        if (o == null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(o);
    }
}
