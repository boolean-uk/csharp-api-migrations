using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static exercise.pizzashopapi.DTO.CustomerDTO;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var orderGroup = app.MapGroup("pizza");
            orderGroup.MapGet("/", GetPizzas);
            orderGroup.MapPost("/", NewPizza);

            var anotherGroup = app.MapGroup("orders");
            anotherGroup.MapGet("/", GetOrders);
            anotherGroup.MapGet("/{id}", GetOrdersByCustomerId);
            anotherGroup.MapPost("/", CreateOrder);

            var thirdGroup = app.MapGroup("customers");
            thirdGroup.MapGet("/", GetCustomers);
            thirdGroup.MapPost("/", CreateCustomer);
        }

        private static async Task<IResult> CreateCustomer(IRepository repository, CreateCustomerDTO customerDTO)
        {
            Customer customer = new()
            {
                Name = customerDTO.customerFullName
            };

            var result = await repository.CreateCustomer(customer);

            return TypedResults.Created($"Customer named {customer.Name} created");
        }

        private static async Task<IResult> CreateOrder(IRepository repository, CreateOrderDTO createdOrder)
        {
            Order order = new() 
            {
                CustomerId = createdOrder.CustomerId,
                PizzaId = createdOrder.PizzaId
            };

            var result = await repository.CreateOrder(order);
            return TypedResults.Created($"Pizza with Id number {result.PizzaId} is created");
        }

        private static async Task<IResult> NewPizza(IRepository repository, CreatePizzaDTO createdPizza)
        {
            Pizza pizza = new()
            {
                Price = createdPizza.Price,
                Name = createdPizza.PizzaName
            };

            var result = await repository.CreatePizza(pizza);
            return TypedResults.Created($"{result.Name} created");
        }

        private static async Task<IResult> GetOrdersByCustomerId(IRepository repository,int id)
        {
            var result = await repository.GetOrdersByCustomerId(id);
            GetResponse<GetOrderDTO> response = new();

            foreach (var order in result)
            {
                decimal calculatedPrice = order.pizza.Price;

                GetOrderDTO orderDTO = new(order.customer.Name, order.pizza.Name, calculatedPrice);
                response.ResponseItems.Add(orderDTO);
            }
            return TypedResults.Ok(response);
        }

        private static async Task<IResult> GetCustomers(IRepository repository)
        {
            var result = await repository.GetCustomers();
            GetResponse<GetCustomerDTO> response = new();

            foreach (var customer in result)
            {
                GetCustomerDTO c = new(customer.Name);
                response.ResponseItems.Add(c);
            }
            return TypedResults.Ok(response);
        }

        private static async Task<IResult> GetOrders(IRepository repository)
        {
            var result = await repository.GetOrders();
            GetResponse<GetOrderDTO> response = new();

            foreach (var order in result)
            {
                decimal calculatedPrice = order.pizza.Price;

                GetOrderDTO orderDTO = new(order.customer.Name, order.pizza.Name, calculatedPrice);
                response.ResponseItems.Add(orderDTO);
            }
            return TypedResults.Ok(response);
        }

        private static async Task<IResult> GetPizzas(IRepository repository)
        {
            var result = await repository.GetPizzas();
            GetResponse<GetPizzaDTO> response = new();

            foreach (var pizza in result)
            {

                GetPizzaDTO p = new(pizza.Name, pizza.Price);
                response.ResponseItems.Add(p);
            }
            return TypedResults.Ok(result);
        }
  
    }
}
