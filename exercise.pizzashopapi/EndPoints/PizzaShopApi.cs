using AutoMapper;
using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var shop = app.MapGroup("shop");

            shop.MapGet("/orders", GetAllOrders);
            shop.MapGet("/pizzas", GetAllPizzas);
            shop.MapGet("/customers", GetAllCustomers);


        }

        public static async Task<IResult> GetAllOrders(IRepository rep, int? customer, IMapper mapper)
        {
            var orders = await rep.GetAllOrders(customer);

            var response = mapper.Map<List<OrderDTO>>(orders);

            return TypedResults.Ok(response);
        }

        public static async Task<IResult> GetAllPizzas(IRepository rep, IMapper mapper)
        {
            var pizzas = await rep.GetAllPizzas();
            var response = mapper.Map<List<PizzaDTO>>(pizzas);

            return TypedResults.Ok(response);
        }

        public static async Task<IResult> GetAllCustomers(IRepository rep, IMapper mapper)
        {
            var customers = await rep.GetAllCustomers();
            var response = mapper.Map<List<CustomerDTO>>(customers);

            return TypedResults.Ok(response);
        }


    }
}
