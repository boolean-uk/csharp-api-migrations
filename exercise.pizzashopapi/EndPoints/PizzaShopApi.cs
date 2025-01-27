using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            

            app.MapGet("/orders", GetOrders);
            app.MapGet("/orders/customer/{id}",GetOrdersByCustomerId);
            app.MapPost("/orders/toppings", AddToppingToOrder);
            app.MapPost("/orders", CreateOrder);
            app.MapGet("/orders/{id}", GetOrderById);
            app.MapPut("/orders/delivered/{id}", SetOrderDelivered);

            app.MapGet("/customers", GetCustomers);

            app.MapGet("/pizzas", GetPizzas);
            app.MapPost("/pizzas", CreatePizza);

            
            app.MapGet("/toppings", GetToppings);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> repo, IMapper mapper)
        {
            var orders = await repo.GetWithNestedIncludes(
                query => query 
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .Include(o => o.OrderToppings).ThenInclude(ot => ot.Toppings)
            );
            var orderDTOs = mapper.Map<List<OrderDTO>>(orders); 
            return TypedResults.Ok(orderDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository<Customer> repo, IMapper mapper)
        {
            var customers = await repo.GetWithNestedIncludes(
                query => query
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
            );
            var dtos = mapper.Map<List<CustomerDTO>>(customers);
            return TypedResults.Ok(dtos);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByCustomerId(IRepository<Customer> repo, int id, IMapper mapper)
        {
            var orders = await repo.GetByIdWithNestedIncludes(c => c.Id == id,
                query => query
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
            );
            var customerDTO = mapper.Map<CustomerDTO>(orders);
            return TypedResults.Ok(customerDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repo, IMapper mapper)
        {
            var pizzas = await repo.Get();
            var pizzaDTOs = mapper.Map<List<PizzaDTO>>(pizzas);
            return TypedResults.Ok(pizzaDTOs);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePizza(IRepository<Pizza> repo, IMapper mapper, PizzaPost model)
        {
            try
            {
                var newPizza = new Pizza()
                {
                    Name = model.Name,
                    Price = model.Price
                };

                var create = await repo.Insert(newPizza);
                var dto = mapper.Map<PizzaDTO>(newPizza);
                return TypedResults.Created($"/{create.Id}", dto);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateOrder(IRepository<Order> repo, IMapper mapper, OrderPost model)
        {
            try
            {
                var newOrder = new Order()
                {
                    CustomerId = model.CustomerId, 
                    PizzaId = model.PizzaId,
                    CreatedAt = DateTime.UtcNow,
                };

                var create = await repo.Insert(newOrder);
                var result = await repo.GetByIdWithNestedIncludes(o => o.Id == create.Id,
                    query => query
                    .Include(o => o.Pizza));
                var dto = mapper.Map<OrderDTO>(newOrder);
                return TypedResults.Created($"/{create.Id}", dto);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddToppingToOrder(
            IRepository<OrderToppings> repo, 
            IMapper mapper, 
            OrderToppingsPost model)
        {
            try
            {
                var newOt = new OrderToppings()
                {
                    OrderId = model.OrderId,
                    ToppingsId = model.ToppingsId
                };

                await repo.Insert(newOt);
                var dto = mapper.Map<OrderToppingsDTO>(newOt);
                return TypedResults.Ok(dto);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetToppings(IRepository<Toppings> repo, IMapper mapper)
        {
            var toppings = await repo.Get();
            var dto = mapper.Map<List<ToppingsDTO>>(toppings);
            return TypedResults.Ok(dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrderById(IRepository<Order> repo, IMapper mapper, int id)
        {
            try
            {
                var order = await repo.GetByIdWithNestedIncludes(o => o.Id == id,
                query => query
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .Include(o => o.OrderToppings).ThenInclude(ot => ot.Toppings)
                );

                var currentStatus = Order.GetOrderStatus(order.CreatedAt, DateTime.UtcNow);
                if (order.Status != currentStatus || order.Status != OrderStatus.Delivered)
                {
                    order.Status = currentStatus;  
                    await repo.Update(order);
                }

                var dto = mapper.Map<OrderDTO>(order);
                return TypedResults.Ok(dto);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> SetOrderDelivered(IRepository<Order> repo, IMapper mapper, int id)
        {
            
            var order = await repo.GetById(id);

            if (order.Status == OrderStatus.Delivered) return TypedResults.Ok("Order already delivered");
            order.Status = OrderStatus.Delivered;
            await repo.Update(order);
            return TypedResults.Ok(new
            {
                Order = order.Id,
                Status = OrderStatus.Delivered.ToString()
            });
        }
    }
}
