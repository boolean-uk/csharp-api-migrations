using exercise.pizzashopapi.Models.Customer;
using exercise.pizzashopapi.Models.Order;
using exercise.pizzashopapi.Models.Pizza;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    [ApiController]
    [Route("pizzas")]
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult BecomeCustomer(IRepository repository, string Name)
        {
            return TypedResults.Ok(repository.BecomeCustomer(Name));


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult UpdateOrder(IRepository repository, int orderId, int pizzaId)
        {
            try
            {
                int numTest = orderId;
                numTest = pizzaId;
                OrderDTO orderDTO = repository.UpdateOrder(orderId, pizzaId);
                return orderDTO != null ? TypedResults.Ok(orderDTO) : TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest();
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult OrderPizza(IRepository repository, int pizzaId, int customerId)
        {
            try
            {
                int numTest = customerId;
                numTest = pizzaId;
                OrderDTO orderDTO = repository.OrderPizza(pizzaId, customerId);
                return orderDTO != null ? TypedResults.Ok(orderDTO) : TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest();
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult GetOrdersByCustomer(IRepository repository, int customerId)
        {
            return TypedResults.Ok(repository.GetOrdersByCustomer(customerId));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult GetOrder(IRepository repository, int orderId)
        {
            return TypedResults.Ok(repository.GetOrder(orderId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult GetOrders(IRepository repository)
        {
            return TypedResults.Ok(repository.GetOrders());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult GetMenuItem(IRepository repository, int pizzaId)
        {
            return TypedResults.Ok(repository.GetMenuItem(pizzaId));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult GetMenu(IRepository repository)
        {
            return TypedResults.Ok(repository.GetMenu());
        }
    }
}
