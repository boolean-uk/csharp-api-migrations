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
            var pizzaGroup = app.MapGroup("pizzashop");

            pizzaGroup.MapGet("/GetOrdersByCustomer", GetOrdersByCustomer);


        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByCustomer(IRepository repo, int customerId)
        {
            var orders = await repo.GetOrdersByCustomer(customerId);
            //make it into DTO 
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            orders.ToList().ForEach(x => orderDTOs.Add(new OrderDTO(x)));
            return TypedResults.Ok(orderDTOs);
        }
    }
}
