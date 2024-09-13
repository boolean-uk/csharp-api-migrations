using exercise.pizzashopapi.Data;
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
            var pizzaGroup = app.MapGroup("order");

            pizzaGroup.MapGet("/", GetOrders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrders (IRepository repository)
        {
            OrderResponseList response = new OrderResponseList();
            var found = await repository.GetOrders();
            if (found != null)
            {
                foreach (var item in found)
                {
                    OrderDTO orderDTO = new() { Name = await repository.GetCustomerNameById(item.CustomerId), Pizza = await repository.GetPizzaNameById(item.PizzaId), Price = await repository.GetPizzaPriceById(item.PizzaId) };
                    response.orders.Add(orderDTO);
                }
                return TypedResults.Ok(response);
            }
            else
            {
                return TypedResults.NotFound("No orders found");
            }
        }
   
    }
}
