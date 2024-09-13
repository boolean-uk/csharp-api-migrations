using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaGroup = app.MapGroup("order");

            pizzaGroup.MapGet("/", GetOrders);
            pizzaGroup.MapGet("/customer{id}", GetOrdersByCustomerId);
            pizzaGroup.MapGet("/ordernr/{id}", GetOrderById);
            pizzaGroup.MapPost("/", CreateOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrders (IRepository repository)
        {
            ResponseList<OrderDTO> response = new ();
            var found = await repository.GetOrders();
            if (found != null)
            {
                foreach (var item in found)
                {
                    OrderDTO orderDTO = new()
                    { 
                        Name = await repository.GetCustomerNameById(item.CustomerId), 
                        Pizza = await repository.GetPizzaNameById(item.PizzaId), 
                        Price = await repository.GetPizzaPriceById(item.PizzaId) 
                    };
                    response.returnedItems.Add(orderDTO);
                }
                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No orders found");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrdersByCustomerId(IRepository repository, int id)
        {
            ResponseList<OrderDTO> response = new ();
            var found = await repository.GetOrdersByCustomerId(id);
            if (found != null)
            {
                foreach (var item in found)
                {
                    OrderDTO orderDTO = new()
                    {
                        Name = await repository.GetCustomerNameById(item.CustomerId),
                        Pizza = await repository.GetPizzaNameById(item.PizzaId),
                        Price = await repository.GetPizzaPriceById(item.PizzaId)
                    };
                    response.returnedItems.Add(orderDTO);
                }
                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No orders found");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrderById(IRepository repository, int id)
        {
            var found = await repository.GetOrderById(id);
            if (found != null)
            {
                OrderDTO orderDTO = new()
                {
                    Name = await repository.GetCustomerNameById(found.CustomerId),
                    Pizza = await repository.GetPizzaNameById(found.PizzaId),
                    Price = await repository.GetPizzaPriceById(found.PizzaId)
                };
                return TypedResults.Ok(orderDTO);
            }
            else
            {
                return TypedResults.NotFound("No orders found");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateOrder(IRepository repository, OrderPOSTModel model)
        {
            int customerId = await repository.GetCustomerIdByName(model.CustomerName);
            int pizzaId = await repository.GetPizzaIdByName(model.PizzaName);

            if (customerId != 0 && pizzaId != 0)
            {
                var newOrder = await repository.CreateOrder(new Order() { CustomerId = customerId, PizzaId = pizzaId });
                OrderDTO orderDTO = new()
                {
                    Name = await repository.GetCustomerNameById(newOrder.CustomerId),
                    Pizza = await repository.GetPizzaNameById(newOrder.PizzaId),
                    Price = await repository.GetPizzaPriceById(newOrder.PizzaId)
                };
                return TypedResults.Created("", orderDTO);
            }
            else
            {
                return TypedResults.BadRequest("Invalid customer or pizza selection");
            }
        }
    }
}
