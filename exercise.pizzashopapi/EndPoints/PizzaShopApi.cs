using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaEndPoint
    {
        public static string error404 = "Does not exist";
        public static string error400 = "Bad request";
        public static void ConfigurePizzaEndpoint(this WebApplication app)
        {
            var pizzaGroup = app.MapGroup("pizza");
            pizzaGroup.MapGet("/pizzas", GetPizzas);
            pizzaGroup.MapGet("/pizzas/{id:int}", GetSinglePizza);
            pizzaGroup.MapPost("/pizzas", CreatePizza);

            pizzaGroup.MapGet("/OrdersByCustomer/{id:int}", GetOrdersByCustomer);
            pizzaGroup.MapGet("/Orders", GetAllOrders);
            pizzaGroup.MapPost("/Orders", CreateOrder);

            pizzaGroup.MapGet("/customers", GetCustomers);
            pizzaGroup.MapGet("/customers/{id:int}", GetSingleCustomer);
            pizzaGroup.MapPost("/customers", CreateCustomer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            var pizzas = await repository.GetPizzas();
            return TypedResults.Ok(pizzas);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> GetSinglePizza(IRepository repository, int id)
        {
            var pizza = await repository.GetSinglePizza(id);
            if (pizza == null)
            {
                return TypedResults.NotFound(error404);
            }
            return TypedResults.Ok(pizza);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public static async Task<IResult> CreatePizza(IRepository repository, Pizza pizza)
        {
            try
            {
                await repository.CreatePizza(pizza);
                return TypedResults.Created("", pizza);
            }
            catch
            {
                return TypedResults.BadRequest(error400);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllOrders(IRepository repository)
        {
            var orders = await repository.GetOrders();
            return TypedResults.Ok(orders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetOrdersByCustomer(IRepository repository, int id)
        {
            var orders = await repository.GetOrdersByCustomer(id);
            return TypedResults.Ok(orders);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> CreateOrder(IRepository repository, int pizzaId, int customerId)
        {
            var order = new Order();

            Pizza pizzaInOrder = await repository.GetSinglePizza(pizzaId);
            Customer customerInOrder = await repository.GetSingleCustomer(customerId);

            if(pizzaInOrder == null || customerInOrder == null)
            {
                return TypedResults.NotFound(error404);
            }

            order.CustomerId = customerId;
            order.customer = customerInOrder;
            order.PizzaId = pizzaId;
            order.Pizza = pizzaInOrder;

            await repository.CreateOrder(order);
            return TypedResults.Created("", order);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            var customers = await repository.GetCustomers();
            return TypedResults.Ok(customers);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> GetSingleCustomer(IRepository repository, int id)
        {
            Customer customer = await repository.GetSingleCustomer(id);
            if(customer == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(customer);
        }

        public static async Task<IResult> CreateCustomer(IRepository repository, Customer customer)
        {
            await repository.CreateCustomer(customer);
            return TypedResults.Created("", customer);
        }
    }
}
