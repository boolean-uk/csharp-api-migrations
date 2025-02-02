using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Repository;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizza = app.MapGroup("shop");

            pizza.MapGet("/pizza", GetPizzas);
            pizza.MapGet("/order", GetOrders);
            //pizza.MapGet("/orderByCustomer{id}", GetOrderByCustomerId);

            //pizza.MapPost("/orderforCustomer", AddOrderForCustomer);
            //pizza.MapPost("/pizza", AddPizza);
            //pizza.MapPost("/topping", AddTopping);


            //pizza.MapPut("/updateOrder{id}", UpdateOrder);
            //pizza.MapPut("/updatePizza{id}", UpdatePizza);

            //pizza.MapDelete("/deleteOrder{id}", DeleteOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repository, IMapper mapper)
        {
            var pizza = await repository.GetWithNestedIncludes(query =>
                query.Include(p => p.Orders)
                     .ThenInclude(a => a.Customer)
            );

            var response = mapper.Map<List<PizzaDTO>>(pizza);

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> repository, IMapper mapper)
        {
            var orders = await repository.GetWithNestedIncludes(query =>
                query.Include(o => o.Customer)
                     .Include(o => o.Pizza)
            );

            var response = mapper.Map<List<OrderDTO>>(orders);
            return TypedResults.Ok(response);
        }


    }
}
