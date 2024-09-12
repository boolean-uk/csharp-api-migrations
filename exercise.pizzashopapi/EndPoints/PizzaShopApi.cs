using AutoMapper;
using exercise.pizzashopapi.Models.DTOs;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Cryptography.X509Certificates;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaShopGroup = app.MapGroup("");

            pizzaShopGroup.MapGet("/orders", GetOrders);
            pizzaShopGroup.MapGet("/order/{id}", GetOrder);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(OrderService orderService, IMapper mapper)
        {
            var orders = await orderService.GetOrders();
            var orderDTOs = mapper.Map<IEnumerable<GetOrderDTO>>(orders);

            return TypedResults.Ok(orderDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrder(OrderService orderService, IMapper mapper, int id)
        {
            var orders = await orderService.GetOrder(id);
            var orderDTO = mapper.Map<GetOrderDTO>(orders);

            if (orderDTO == null)
                return TypedResults.NotFound("Order not found");

            return TypedResults.Ok(orderDTO);
        }
    }
}
