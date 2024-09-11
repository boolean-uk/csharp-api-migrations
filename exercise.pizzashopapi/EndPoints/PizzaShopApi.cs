using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaShop = app.MapGroup("shop");
            
            pizzaShop.MapGet("/customers", GetCustomers);
            pizzaShop.MapGet("/customers/{id}", GetCustomerById);
            pizzaShop.MapPost("/customers", AddCustomer);
            pizzaShop.MapGet("/pizzas", GetPizzas);
            pizzaShop.MapGet("/pizzas/{id}", GetPizzaById);
            pizzaShop.MapPost("/pizzas", AddPizza);
            pizzaShop.MapGet("/orders", GetOrders);
            pizzaShop.MapGet("/orders/{id}", GetOrderById);
            pizzaShop.MapPost("/orders", AddOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetCustomers(IRepository repo)
        {
            var list = await repo.GetAllCustomers();
            var dto = list.Select(c => new CustomerDTO(c.Name, [])).ToList();
            return TypedResults.Ok(dto);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetCustomerById(IRepository repo, int id)
        {
            var c = await repo.GetCustomer(id);
            if (c == null) return TypedResults.NotFound("Customer not found");
            var orderList = c.Orders.Select(o => new CustomerOrderDTO(o.OrderDate, o.Pizza.Name, o.Pizza.Price)).ToList();
            return TypedResults.Ok(new CustomerDTO(c.Name, orderList));
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> AddCustomer(IRepository repo, CustomerPostModel model)
        {
            var response = await repo.AddCustomer(new Customer() { Name = model.Name });
            if (response == null) return TypedResults.BadRequest("Error occured. Customer not created");
            return TypedResults.Created($"/customers/{response.Id}", response);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPizzas(IRepository repo)
        {
            var list = await repo.GetAllPizzas();
            return TypedResults.Ok(list);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPizzaById(IRepository repo, int id)
        {
            var p = await repo.GetPizza(id);
            return TypedResults.Ok(p);
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddPizza(IRepository repo, PizzaPostModel model)
        {
            var response = await repo.AddPizza(new Pizza() { Name = model.Name, Price = model.Price });
            return TypedResults.Created($"/pizzas/{response.Id}", response);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetOrders(IRepository repo)
        {
            var list = await repo.GetAllOrders();
            var dto = list.Select(o => new OrderDTO(o.OrderDate, o.Customer.Name, o.Pizza.Name, o.Pizza.Price)).ToList();
            return TypedResults.Ok(dto);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetOrderById(IRepository repo, int id)
        {
            var o = await repo.GetOrder(id);
            return TypedResults.Ok(o);
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> AddOrder(IRepository repo, OrderPostModel model)
        {
            var customer = await repo.GetCustomer(model.CustomerId);
            if (customer == null) return TypedResults.BadRequest($"Customer with id {model.CustomerId} not found");
            var pizza = await repo.GetPizza(model.PizzaId);
            if (pizza == null) return TypedResults.BadRequest($"Pizza with id {model.PizzaId} not found");
            var order = await repo.AddOrder(new Order()
            {
                OrderDate = DateTime.UtcNow,
                CustomerId = model.CustomerId,
                PizzaId = model.PizzaId
            });
            if (order == null) return TypedResults.BadRequest("Error occured. Order not created");
            var response = new OrderDTO(order.OrderDate, order.Customer.Name, order.Pizza.Name, order.Pizza.Price);
            return TypedResults.Created($"/orders/{order.Id}", response);
        }
    }
}
