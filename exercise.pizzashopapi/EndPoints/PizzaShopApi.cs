using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {

            var shop = app.MapGroup("shop");
            shop.MapGet("/orders", GetOrders);
            shop.MapGet("/pizzas", GetPizzas);
            shop.MapGet("/orderStatus", GetOrderStatus);
            shop.MapPost("/orders", CreateOrder);
            
        }

        private static async Task<IResult> CreateOrder(HttpContext context, IRepository<Order> o_repo, CreateOrderDTO dto)
        {
            try
            {
                Order order = new()
                {
                    CustomerId = dto.CustomerId,
                    PizzaId = dto.PizzaID,
                    OrderToppings = dto.Toppings.Select(
                        x => new OrderToppings
                        {
                            Amount = x.amount,
                            ToppingId = x.ToppingId
                        }).ToList()
                };
                var _order = await o_repo.CreateEntry(order);
                if (_order == null) return TypedResults.BadRequest($"Not a valid DTO");

                var retOrder = await o_repo.GetEntry(o => 
                    o.Where( x => x.Id == _order.Id),
                    x => x.Include(x => x.Customer),
                    x => x.Include(x => x.Pizza),
                    x => x.Include(x => x.OrderToppings).ThenInclude(x=>x.Topping)
                );

                return TypedResults.Ok(new OrderDTO(retOrder));
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest($"Something bad happened");
            }
        }
        private static async Task<IResult> GetOrders(HttpContext context, IRepository<Order> o_repo, int? customerId, int? orderID)
        {
            if (customerId == null && orderID == null) return await _GetOrders(context, o_repo);
            if (customerId == null && orderID != null) return await _GetOrdersByOrderId(context, o_repo, orderID.Value);
            else
                return await _GetOrdersByCustomerId(context, o_repo, customerId.Value);
        }


        private static async Task<IResult> GetOrderStatus(HttpContext context, IRepository<Order> o_rep, int orderId)
        {
            var l = await o_rep.GetEntry(
                    w => w.Where(x => x.Id == orderId),
                    x => x.Include(x => x.Pizza),
                    x => x.Include(x => x.Customer),
                    x => x.Include(x => x.OrderToppings).ThenInclude(x => x.Topping)
                    );

            if (l == null) return TypedResults.NotFound();

            var dur = DateTime.Now.ToUniversalTime() - l.startTime;
            return TypedResults.Ok(new {  
                Status= dur.TotalMinutes <= 3 ? "Chef preparing your meal" : dur.TotalMinutes > 15 ? "Your meal should be delivered!" : "Your meal is on they way!" , 
            });
        }

        private static async Task<IResult> GetPizzas(HttpContext context, IRepository<Pizza> p_rep)
        {
            var l = await p_rep.GetEntries();
            if (l.Count() == 0) return TypedResults.NotFound();
            return  TypedResults.Ok(l.Select(x => new PizzaDTO(x)).ToList());
        }
        private static async Task<IResult> _GetOrdersByCustomerId(HttpContext context, IRepository<Order> o_repo, int customerId)
        {
            var l = await o_repo.GetEntries(
                    w => w.Where(x => x.CustomerId == customerId),
                    x => x.Include(x => x.Pizza), 
                    x => x.Include(x => x.Customer), 
                    x => x.Include(x => x.OrderToppings).ThenInclude(x =>x.Topping)
                );
            if (l == null) return TypedResults.NotFound();
            return TypedResults.Ok(l.Select(x => new OrderDTO(x)).ToList());
        }
        private static async Task<IResult> _GetOrdersByOrderId(HttpContext context, IRepository<Order> o_repo, int orderID)
        {
            var l = await o_repo.GetEntry(
                    w => w.Where(x => x.Id == orderID),
                    x => x.Include(x => x.Pizza), 
                    x => x.Include(x => x.Customer), 
                    x => x.Include(x => x.OrderToppings).ThenInclude(x =>x.Topping)
                );
            if (l == null) return TypedResults.NotFound();
            return TypedResults.Ok(new OrderDTO(l));
        }

        
        private static async Task<IResult> _GetOrders(HttpContext contextint, IRepository<Order> o_rep)
        {
            var l = await o_rep.GetEntries(
                x => x.Include(x => x.Pizza),
                x => x.Include(x => x.Customer),
                x => x.Include(x => x.OrderToppings).ThenInclude(x => x.Topping)
            );
            if (l.Count() == 0) return TypedResults.NotFound();
            return TypedResults.Ok(l.Select(x => new OrderDTO(x)).ToList());
        }
    }
}
