using AutoMapper;
using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizza = app.MapGroup("/pizzas");

            pizza.MapGet("", GetPizzas);
            pizza.MapGet("/orders/{id}", GetOrdersById);
            pizza.MapPost("/orders", CreateOrder);


                
        }

        #region PizzaEndpoints

        public static async Task<IResult> GetPizzas(IRepository<Pizza> pizzaRepository, IMapper mapper)
        {
            var pizzas = await pizzaRepository.GetAll();
            return Results.Ok(mapper.Map<IEnumerable<PizzaDTO>>(pizzas));
        }


        #endregion

        #region ToppingEndpoints

        public static async Task<IResult> GetToppings(IRepository<Topping> toppingRepository, IMapper mapper)
        {
            var toppings = await toppingRepository.GetAll();
            return Results.Ok(mapper.Map<IEnumerable<ToppingDTO>>(toppings));
        }
        
        #endregion

        #region OrderEndpoints

        public static async Task<IResult> GetOrders(IRepository<Order> orderRepository, IMapper mapper)
        {
            var orders = await orderRepository.GetAll();
            return Results.Ok(mapper.Map<IEnumerable<OrderDTO>>(orders));
        }
        public static async Task<IResult> GetOrdersById(IRepository<Order> orderRepository, int id, IMapper mapper)
        {
            var orders = await orderRepository.GetAll();
            orders = orders.Where(o => o.CustomerId == id);
            return Results.Ok(mapper.Map<IEnumerable<OrderDTO>>(orders));
        }

        public static async Task<IResult> CreateOrder(IRepository<Order> orderRepository, CreateOrderDTO orderDTO, IMapper mapper)
        {
            Order order = new Order()
            {
                CustomerId = orderDTO.CustomerId,
                PizzaId = orderDTO.PizzaId
            };
            List<OrderToppings> orderToppings = new List<OrderToppings>();
            foreach (var topping in orderDTO.Toppings)
            {
                orderToppings.Add(new OrderToppings()
                {
                    ToppingId = topping
                });
            }
            order.OrderToppings = orderToppings;
 


            var newOrder = await orderRepository.CreateEntity(order);
            return Results.Ok("Order created!");
            
        }



        #endregion

       
    }
}
