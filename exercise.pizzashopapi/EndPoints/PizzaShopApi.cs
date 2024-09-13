using AutoMapper;
using exercise.pizzashopapi.Models.DTOs;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using exercise.pizzashopapi.Models;
using System.Runtime.InteropServices;
using exercise.pizzashopapi.Enum;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaShopGroup = app.MapGroup("");

            pizzaShopGroup.MapGet("/orders", GetOrders);
            pizzaShopGroup.MapGet("/orders/{id}", GetOrder);
            pizzaShopGroup.MapPost("/orders/", CreateOrder);
            pizzaShopGroup.MapPut("/orders/{id}", UpdateOrderStatus);

            pizzaShopGroup.MapGet("/pizzas/", GetPizzas);
            pizzaShopGroup.MapGet("/pizza/{id}", GetPizza);
            pizzaShopGroup.MapPost("/pizza/", CreatePizza);

            pizzaShopGroup.MapGet("/customers/", GetCustomers);
            pizzaShopGroup.MapGet("/customers/{id}", GetCustomer);
            pizzaShopGroup.MapPost("/customers/", CreateCustomer);


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

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateOrder(OrderService orderService, IMapper mapper, CreateOrderDTO orderDTO)
        {
          
            Order order = mapper.Map<Order>(orderDTO);

            Order createdOrder = await orderService.CreateOrder(order);

            var getOrderDTO = mapper.Map<GetOrderDTO>(createdOrder);

            return TypedResults.Ok(getOrderDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(PizzaService pizzaService, IMapper mapper)
        {
            var pizzas = await pizzaService.GetPizzas();

            return TypedResults.Ok(pizzas);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizza(PizzaService pizzaService, IMapper mapper, int id)
        {
            Pizza pizza = await pizzaService.GetPizza(id);

            if (pizza == null)
                return TypedResults.NotFound("Pizza not found");

            return TypedResults.Ok(pizza);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePizza(PizzaService pizzaService, IMapper mapper, CreatePizzaDTO pizzaDTO)
        {
            Pizza pizza = mapper.Map<Pizza>(pizzaDTO);

            Pizza createdPizza = await pizzaService.CreatePizza(pizza);

            return TypedResults.Ok(createdPizza);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(CustomerService customerService, IMapper mapper)
        {
            var customers = await customerService.GetCustomers();

            var customersDTO = mapper.Map<IEnumerable<GetCustomerDTO>>(customers);

            return TypedResults.Ok(customersDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomer(CustomerService customerService, IMapper mapper, int id)
        {
            var customer = await customerService.GetCustomer(id);

            var customersDTO = mapper.Map<GetCustomerDTO>(customer);

            return TypedResults.Ok(customersDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCustomer(CustomerService customerService, IMapper mapper, CreateCustomerDTO customerDTO)
        {
            Customer customer = mapper.Map<Customer>(customerDTO);

            Customer createdCustomer = await customerService.CreateCustomer(customer);

            return TypedResults.Ok(createdCustomer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateOrderStatus(OrderService orderService, IMapper mapper, int id, UpdateOrderDTO orderDTO)
        {
            

            Order updatedOrder = await orderService.UpdateOrder(id, orderDTO);

            return TypedResults.Ok(updatedOrder);
        }

    }
}
