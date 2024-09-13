using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzashop = app.MapGroup("pizzashop");
            pizzashop.MapGet("/pizzas", GetPizzas);
            pizzashop.MapGet("/pizzas/{id}", GetPizzaById);
            pizzashop.MapGet("/customers", GetCustomers);
            pizzashop.MapGet("/customers/{id}", GetCustomerById);
            pizzashop.MapPost("/pizzas", CreatePizza);
            pizzashop.MapGet("/orders", GetOrders);
            pizzashop.MapGet("/orders/{id}", GetOrderByCustomerId);
            pizzashop.MapPost("/orders", CreateOrder);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            List<Pizza> response = await repository.GetPizzas();
            return response != null ? TypedResults.Ok(response) : TypedResults.NotFound();

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzaById(IRepository repository, int id)
        {
            var pizza = await repository.GetPizzaById(id);
            return pizza != null ? TypedResults.Ok(pizza) : TypedResults.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreatePizza(IRepository repository, PostPizzaModel model)
        {
            try
            {
                var pizza = await repository.CreatePizza(new Pizza() { Name = model.Name, Price = model.Price });
                pizza = await repository.GetPizzaById(pizza.Id);
                return TypedResults.Created($"/pizzas/{pizza.Id}", pizza);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(); 
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            List<Customer> response = await repository.GetCustomers();
            return response != null ? TypedResults.Ok(response) : TypedResults.NotFound();

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomerById(IRepository repository, int id)
        {
            var customer = await repository.GetCustomerById(id);
            return customer != null ? TypedResults.Ok(customer) : TypedResults.NotFound();

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrders(IRepository repository)
        {
            List<Order> response = await repository.GetOrders();
            return response != null ? TypedResults.Ok(response) : TypedResults.NotFound();

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrderByCustomerId(IRepository repository, int id)
        {
            List<Order> response = await repository.GetOrderByCustomerId(id);
            return response != null ? TypedResults.Ok(response) : TypedResults.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateOrder(IRepository repository, PostOrderModel model)
        {
            Customer customer = await repository.GetCustomerById(model.CustomerId);
            Pizza pizza = await repository.GetPizzaById(model.PizzaId);

            if (customer == null && pizza == null)
            {
                return TypedResults.NotFound();
            }

            Order order = new Order() { CustomerId = model.CustomerId, PizzaId = model.PizzaId };
            var newOrder = await repository.CreateOrder(order);
            OrderDTO payload = new OrderDTO() { Customer = customer.Name, Pizza = pizza.Name };
            return TypedResults.Ok(payload);
        }

    }
}
