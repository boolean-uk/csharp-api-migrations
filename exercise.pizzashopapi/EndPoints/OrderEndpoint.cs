using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class OrderEndpoint
    {
        public static void ConfigureOrderEndpoint(this WebApplication app)
        {
            var orders = app.MapGroup("orders");

            orders.MapGet("/GetAll", GetOrders);
            orders.MapGet("/GetById{id}", GetOrder);
            orders.MapGet("/GetByCustomerId{id}", GetCustomerOrder);
            orders.MapPost("/Create{customerId}|{pizzaId}", CreateOrder);
            orders.MapDelete("/Remove{id}", RemoveOrder);
            orders.MapPut("/MarkAsDelivered{id}", MarkDelivered);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetOrders());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetOrder(IRepository repository, int id)
        {
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetCustomerOrder(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetOrderByCustomerId(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateOrder(IRepository repository, int customerId, int pizzaId)
        {
            try
            {
                //Check if we can find customer and pizza
                var customer = await repository.GetCustomerById(customerId);
                if(customer == null)
                {
                    TypedResults.NotFound();
                }

                var pizza = await repository.GetPizzaById(pizzaId);
                if(pizza == null)
                {
                    TypedResults.NotFound();
                }

                //Create the order
                Order order = new Order() { CustomerId = customerId, PizzaId = pizzaId };

                var result = await repository.AddOrder(order);

                //Response
                return TypedResults.Created($"http://localhost:7138/Orders/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> RemoveOrder(IRepository repository, int id)
        {
            try
            {
                //Check if the order exists
                var order = await repository.GetOrderById(id);
                if(order == null)
                {
                    return TypedResults.NotFound();
                }

                var result = await repository.RemoveOrder(id);

                //Response
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> MarkDelivered(IRepository repository, int id)
        {
            try
            {
                //Check if the order is transporting or not
                var order = await repository.GetOrderById(id);
                if (order.Status != "Transporting")
                {
                    return TypedResults.BadRequest();
                }

                var result = await repository.OrderDelivered(id);

                //Response
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
