using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {

            var pizzaGroup = app.MapGroup("pizzaShop");
            pizzaGroup.MapGet("/pizza", GetAllPizza);
            pizzaGroup.MapGet("/pizza/{id}", GetAPizza);
            pizzaGroup.MapPost("/pizza", CreateAPizza);
            pizzaGroup.MapPut("/pizza", EditAPizza);
            pizzaGroup.MapDelete("/pizza/{id}", DeleteAPizza);

            pizzaGroup.MapGet("/orders", GetAllOrders);
            pizzaGroup.MapGet("/orders/{id}", GetAOrder);
            pizzaGroup.MapPost("/orders", CreateAnOrder);
            pizzaGroup.MapPut("/orders", EditAnOrder);
            pizzaGroup.MapPut("/orders/{id}/{status}", updateOrderStatus);
            pizzaGroup.MapDelete("/orders/{id}", DeleteAnOrder);

            pizzaGroup.MapGet("/customer", GetAllCustomers);
            pizzaGroup.MapGet("/customer/{id}", GetACustomer);

        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllPizza(IRepository<Pizza> repository)
        {
            var list = await repository.getAll();
            var pizzaDtos = list.Select(p => new GetPizzaDTO { pizzaId = p.Id, pizzaName = p.Name, pizzaPrice = p.Price }).ToList();
            if (pizzaDtos.Count == 0) { return Results.NotFound(); }
            return TypedResults.Ok(pizzaDtos);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAPizza(IRepository<Pizza> repository, int id)
        {
            var pizza = await repository.getbyId(id);
            if (pizza == null) { return Results.NotFound(); }
            var pizzaDto = new GetPizzaDTO { pizzaId = pizza.Id, pizzaName = pizza.Name, pizzaPrice = pizza.Price };
            return TypedResults.Ok(pizzaDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAPizza(IRepository<Pizza> repository, CreatePizzaDTO dto)
        {
            var pizza = new Pizza { Name = dto.name, Price = dto.price };
            if (dto == null)
            {
                return Results.NotFound();
            }
            var result = await repository.Add(pizza);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> EditAPizza(IRepository<Pizza> repository, CreatePizzaDTO dto)
        {
            var pizza = new Pizza { Name = dto.name, Price = dto.price };
            if (dto == null)
            {
                return Results.NotFound();
            }
            var result = await repository.Update(pizza);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteAPizza(IRepository<Pizza> repository, int id)
        {
            var pizza = await repository.Delete(id);
            if (pizza == null) { return Results.NotFound(); }
            return TypedResults.Ok(pizza);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllOrders(IRepository<Order> repository)
        {
            var list = await repository.getAllWithIncludes();
            var orderDtos = list.Select(o => new GetOrderDTO {
                orderDate = o.OrderDate,
                customerName = o.customer.Name,
                pizzaName = o.pizza.Name,
                delivered = o.delivered,
                state = o.orderState
                }).ToList();
            if (orderDtos.Count == 0) { return Results.NotFound(); }
            return TypedResults.Ok(orderDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAOrder(IRepository<Order> repository, int id)
        {
            var order = await repository.getByIdWithIncludes(id);
            if (order == null) { return Results.NotFound(); }
            var orderDto = new GetOrderDTO { orderDate = order.OrderDate,
                customerName = order.customer.Name,
                pizzaName = order.pizza.Name,
                state = order.orderState,
                delivered = order.delivered
            };
            return TypedResults.Ok(orderDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateAnOrder(IRepository<Order> repository, CreateOrderDTO dto)
        {
            var order = new Order { OrderDate = DateOnly.FromDateTime(DateTime.Now), CustomerId = dto.customerId, PizzaId = dto.pizzaId };
            if (dto == null)
            {
                return Results.NotFound();
            }
            var result = await repository.Add(order);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> EditAnOrder(IRepository<Order> repository, CreateOrderDTO dto)
        {
            var order = new Order { OrderDate = DateOnly.FromDateTime(DateTime.Now), CustomerId = dto.customerId, PizzaId = dto.pizzaId };
            if (dto == null)
            {
                return Results.NotFound();
            }
            var result = await repository.Update(order);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteAnOrder(IRepository<Order> repository, int id)
        {
            var order = await repository.Delete(id);
            if (order == null) { return Results.NotFound(); }
            return TypedResults.Ok(order);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetAllCustomers(IRepository<Customer> repository)
        {
            var list = await repository.getAll();
            if (list.Count() == 0) { return Results.NotFound(); }
            return TypedResults.Ok(list);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetACustomer(IRepository<Customer> repository, int id)
        {
            var customer = await repository.getbyId(id);
            if (customer == null) { return Results.NotFound(); }
            return TypedResults.Ok(customer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> updateOrderStatus(OrderRepository repository, int id, bool status)
        {
            var order = await repository.getbyId(id);
            await repository.updateOrderStatus(id, status);
            
            if (order == null) { return Results.NotFound(); }
                return TypedResults.Ok(order.delivered);
        }
    }
}
