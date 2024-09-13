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
            app.MapGet("/pizzas", GetAllPizzas);
            app.MapGet("/pizzas/{id}", GetPizzaById);
            app.MapGet("/orders", GetAllOrders);
            app.MapGet("/orders/{customerId}", GetOrdersByCustomerId);
            app.MapPut("/orders/update/{customerId}/{pizzaId}", UpdateOrderStatus);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllPizzas(IRepository<Pizza> repository)
        {
            try
            {
                var result = await repository.GetAllWithIncludes();

                List<GetPizzaDTO> pizzas = new List<GetPizzaDTO>();

                foreach (var pizza in result)
                {

                    PizzaOrderDTO orderDTO = new PizzaOrderDTO()
                    {
                        orderTime = pizza.Order.OrderTime,
                        status = pizza.Order.Status,
                        customer = pizza.Order.Customer.Name,
                    };

                    GetPizzaDTO pDto = new GetPizzaDTO()
                    {
                        Name = pizza.Name,
                        Price = pizza.Price,
                        Order = orderDTO
                    };

                    pizzas.Add(pDto);
                }
                return TypedResults.Ok(pizzas);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzaById(IRepository<Pizza> repository, int id)
        {
            try
            {

                var pizzaTarget = await repository.GetByIdWithIncludes(id);

                PizzaOrderDTO orderDTO = new PizzaOrderDTO()
                {
                    orderTime = pizzaTarget.Order.OrderTime,
                    status = pizzaTarget.Order.Status,
                    customer = pizzaTarget.Order.Customer.Name,
                };

                GetPizzaDTO pDto = new GetPizzaDTO()
                {
                    Name = pizzaTarget.Name,
                    Price = pizzaTarget.Price,
                    Order = orderDTO
                };

                return TypedResults.Ok(pDto);

            }
            catch (Exception)
            {

                return TypedResults.NotFound("Pizza not found!");
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllOrders(IRepository<Order> repository)
        {
            try
            {
                var result = await repository.GetAllWithIncludes();

                List<OrderDTO> orders = new List<OrderDTO>();

                foreach (var order in result)
                {
                    OrderDTO orderDTO = new OrderDTO()
                    {
                        Customer = order.Customer.Name,
                        Pizza = order.Pizza.Name,
                        orderTime = order.OrderTime,
                        status = order.Status
                    };

                    orders.Add(orderDTO);
                }

                return TypedResults.Ok(orders);
            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrdersByCustomerId(OrderRepository repository, int customerId)
        {
            try
            {
                var result = await repository.GetOrdersByCustomerId(customerId);

                List<OrderDTO> orders = new List<OrderDTO>();

                foreach (var order in result)
                {
                    OrderDTO orderDTO = new OrderDTO()
                    {
                        Customer = order.Customer.Name,
                        Pizza = order.Pizza.Name,
                        orderTime = order.OrderTime,
                        status = order.Status
                    };

                    orders.Add(orderDTO);
                }

                return TypedResults.Ok(orders);
            }
            catch (Exception)
            {

                return TypedResults.NotFound("Orders not found!");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateOrderStatus(OrderRepository repository, UpdateOrderDTO newStatus)
        {
            try
            {
                if (newStatus == null) { return TypedResults.NotFound(); }

                var updatedOrder = new Order()
                {
                    CustomerId = newStatus.customerId,
                    PizzaId = newStatus.pizzaId,
                    Status = newStatus.status
                };


                var result = await repository.UdateOrderStatus(updatedOrder.CustomerId, updatedOrder.PizzaId, updatedOrder.Status);


                OrderDTO orderDTO = new OrderDTO()
                {
                    Customer = result.Customer.Name,
                    Pizza = result.Pizza.Name,
                    orderTime = result.OrderTime,
                    status = result.Status
                };

                return TypedResults.Ok(orderDTO);
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest(ex.Message);
            }
        }

    }



}
