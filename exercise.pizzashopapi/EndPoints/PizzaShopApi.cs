using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var ordergroup = app.MapGroup("orders");
            ordergroup.MapGet("/", GetOrders);
            ordergroup.MapGet("/{id}", GetOrder);
            ordergroup.MapGet("/customer/{id}", GetOrdersByCustomerId);
        }

        private static async Task<IResult> GetOrders(IRepository<Order> repository, IMapper mapper)
        {
            var orders = await repository.GetAll(o => o.Customer, o => o.Pizza);
            var response = mapper.Map<IEnumerable<OrderResponse>>(orders);
            
            return TypedResults.Ok(response);
        }
        
        private static async Task<IResult> GetOrder(IRepository<Order> repository, IMapper mapper, int id)
        {
            var order = await repository.Get(o => o.Id == id, o => o.Customer, o => o.Pizza);
            var response = mapper.Map<OrderResponse>(order);
            
            return TypedResults.Ok(response);
        }
        
        private static async Task<IResult> GetOrdersByCustomerId(IRepository<Order> repository, IMapper mapper, int id)
        {
            var orders = await repository.GetAll(o => o.CustomerId == id, o => o.Pizza);
            var response = mapper.Map<IEnumerable<OrderResponse>>(orders);
            
            return TypedResults.Ok(response);
        }
    }
}
