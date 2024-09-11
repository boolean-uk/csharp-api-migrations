using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class BobsPizzaShopAPI
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var bobsGroup = app.MapGroup("BobsPizza");

            bobsGroup.MapGet("/orderByCustomerId/{id}", GetOrdersByCustomerId);
            bobsGroup.MapGet("/orders", GetOrders);
            bobsGroup.MapGet("/orderById/{id}", GetOrderById);
            bobsGroup.MapGet("/customers", GetCustomers);
            bobsGroup.MapGet("/customerById/{id}", GetCustomerById);
            bobsGroup.MapGet("/pizzaById/{id}", GetPizzaById);
            bobsGroup.MapGet("/pizzas", GetPizzas);
            bobsGroup.MapPost("/CreatePizza/{name, price}", AddPizza);
            bobsGroup.MapPost("/CreateOrder/{customerId, pizzaId}", AddOrder);
            bobsGroup.MapPost("/CreateCustomer/{name}", AddCustomer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddCustomer(IRepository repository, CustomerPayload payload)
        {
            if(payload.Name == null || payload.Name.Length == 0)
            {
                return TypedResults.BadRequest("Invalid name");
            }
            return TypedResults.Ok(await repository.AddCustomer(payload));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddOrder(IRepository repository, int customerId, int pizzaId)
        {
            if(!await repository.CheckExists(0, customerId))
            {
                return TypedResults.NotFound("Customer not found");
            }
            if (!await repository.CheckExists(1, pizzaId))
            {
                return TypedResults.NotFound("Pizza not found");
            }
            return TypedResults.Ok(await repository.AddOrder(customerId, pizzaId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPizza(IRepository repository, PizzaPayload payload)
        {
            if(payload.Name == null || payload.Name.Length==0)
            {
                return TypedResults.BadRequest("Invalid name");
            }
            if (payload.Price < 0)
            {
                return TypedResults.BadRequest("Price cannot be negative");
            }
            return TypedResults.Ok(await repository.AddPizza(payload));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPizzas());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetPizzaById(IRepository repository, int id)
        {
            if (id < 1)
            {
                return TypedResults.BadRequest("ID cannot be less than 1");
            }
            try
            {
                return TypedResults.Ok(await repository.GetPizza(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomerById(IRepository repository, int id)
        {
            if (id < 1)
            {
                return TypedResults.BadRequest("ID cannot be less than 1");
            }
            try
            {
                return TypedResults.Ok(await repository.GetCustomer(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetCustomers());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetOrderById(IRepository repository, int id)
        {
            if (id < 1)
            {
                return TypedResults.BadRequest("ID cannot be less than 1");
            }
            try
            {
                return TypedResults.Ok(await repository.GetOrderById(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetOrders());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetOrdersByCustomerId(IRepository repository, int id)
        {
            if (id < 1)
            {
                return TypedResults.BadRequest("ID cannot be less than 1");
            }
            try
            {
                return TypedResults.Ok(await repository.GetOrdersByCustomerId(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
