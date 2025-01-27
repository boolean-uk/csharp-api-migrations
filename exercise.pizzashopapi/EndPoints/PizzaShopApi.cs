using System.Security.Cryptography.X509Certificates;
using exercise.pizzashopapi.DTOS;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {

            var PizzaShop = app.MapGroup("PizzaShop");

            PizzaShop.MapGet("/orders", GetOrders);
            PizzaShop.MapGet("/order/{id}", GetOrderById);
        

            PizzaShop.MapGet("/pizzas", GetPizzas);
            PizzaShop.MapGet("/pizza/{id}", GetPizzaById);

            PizzaShop.MapGet("/customers", GetCustomers);
            PizzaShop.MapGet("/customer/{id}", GetCustomerById);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrders(IRepository repo)
        {
            var orders = await repo.GetOrders();

            if (orders == null)

            {
                return TypedResults.NotFound("Could not find any orders");

            }

            var orderDto = orders.Select( o => new OrderDTO
            {

                CustomerName = o.Customer.Name,
                PizzaName = o.Pizza.Name,
                Price = o.Pizza.Price,
                }).ToList();
           
            return TypedResults.Ok(orderDto);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrderById(IRepository repo, int id)
        {
            var order = await repo.GetOrderById(id);

            if (order == null)

            {
                return TypedResults.NotFound($"Order with the id:{id} not found");

            }

            var orderDto = new OrderDTO

            {
                CustomerName= order.Customer.Name,
                PizzaName= order.Pizza.Name,
                Price = order.Pizza.Price,

            };

            return TypedResults.Ok(orderDto);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzas(IRepository repo)
        {
            var pizzas = await repo.GetPizzas();

            if (pizzas == null)

            {
                return TypedResults.NotFound("Could not find any pizzas");

            }

            var pizzaDto = pizzas.Select(p => new PizzaDTO
            {
                PizzaId = p.Id,
                PizzaName = p.Name,
                Price = p.Price,
                }).ToList();

            return TypedResults.Ok(pizzaDto);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzaById(IRepository repo, int id)

        {
            var pizza = await repo.GetPizzaById(id);

            if (pizza == null)

            {
                return TypedResults.NotFound($"Pizza with the id:{id} not found");
            }

            var pizzaDto = new PizzaDTO
            {
                PizzaId = pizza.Id,
                PizzaName = pizza.Name,
                Price = pizza.Price,

            };

            return TypedResults.Ok(pizzaDto);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomers(IRepository repo)
        {
            var customers = await repo.GetCustomers();

            if (customers == null)
            {
                return TypedResults.NotFound("Could not find any customers");
            
            }

            var customerDto = customers.Select(c => new CustomerDTO
            {
                CustomerId = c.Id,
                Name = c.Name
                }).ToList();

            return TypedResults.Ok(customerDto);  
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomerById(IRepository repo, int id)
        {
            var customer = await repo.GetCustomerById(id);

            if (customer == null)

            {
                return TypedResults.NotFound($"Customer with the id:{id} not found");

            }

            var customerDto =  new CustomerDTO

            { 
                CustomerId = customer.Id,
                Name = customer.Name
            };

            return TypedResults.Ok(customerDto);

        }











    }
}
