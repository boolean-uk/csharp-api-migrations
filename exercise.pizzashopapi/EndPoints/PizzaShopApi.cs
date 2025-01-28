using AutoMapper;
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
            var ordergroup = app.MapGroup("orders");
            ordergroup.MapGet("/", GetOrders);
            ordergroup.MapGet("/{id}", GetOrder);
            ordergroup.MapGet("/customer/{id}", GetOrdersByCustomerId);
            ordergroup.MapPut("/{id}", UpdateOrder);
        }

        private static async Task<IResult> GetOrders(IRepository<Order> repository, IMapper mapper)
        {
            var orders = await repository.GetAll(o => o.Customer, o => o.Pizza, o => o.Toppings);
            var response = mapper.Map<IEnumerable<OrderResponse>>(orders);
            
            return TypedResults.Ok(response);
        }
        
        private static async Task<IResult> GetOrder(IRepository<Order> repository, IMapper mapper, int id)
        {
            var order = await repository.Get(o => o.Id == id, o => o.Customer, o => o.Pizza, o => o.Toppings);
            var response = mapper.Map<OrderResponse>(order);
            
            return TypedResults.Ok(response);
        }
        
        private static async Task<IResult> GetOrdersByCustomerId(IRepository<Order> repository, IMapper mapper, int id)
        {
            var orders = await repository.GetAll(o => o.CustomerId == id, o => o.Pizza, o => o.Toppings);
            var response = mapper.Map<IEnumerable<OrderResponse>>(orders);
            
            return TypedResults.Ok(response);
        }
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateOrder(IRepository<Order> orderRepository, IRepository<Topping> toppingRepository, IMapper mapper, int id, [FromBody] OrderPut body)
        {
            var order = await orderRepository.Get(o => o.Id == id);
            if (order == null) return TypedResults.NotFound();
            
            var validToppings = new HashSet<Topping>();
            foreach (var toppingId in body.ToppingIds)
            {
                var topping = await toppingRepository.Get(t => t.Id == toppingId);
                if (topping != null)
                {
                    validToppings.Add(topping);
                }
            }

            foreach (var topping in validToppings)
            {
                if (order.Toppings is not null && !order.Toppings.Contains(topping))
                {
                    return TypedResults.BadRequest("Can't remove already added toppings.");
                }
            }
            
            order.Toppings = validToppings.ToList();
            await orderRepository.Update(order);

            return TypedResults.NoContent();
        }
    }
}
