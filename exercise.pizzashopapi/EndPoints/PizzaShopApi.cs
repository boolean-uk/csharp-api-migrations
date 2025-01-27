using System.Security.Cryptography.X509Certificates;
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
            return TypedResults.Ok(orders);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrderById(IRepository repo, int id)
        {
            var order = await repo.GetOrderById(id);

            if (order == null)

            {
                return TypedResults.NotFound($"Order with the id:{id} not found");

            }

            return TypedResults.Ok(order);

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

            return TypedResults.Ok(pizzas);

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

            return TypedResults.Ok(pizza);

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

            return TypedResults.Ok(customers);  
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

            return TypedResults.Ok(customer);

        }











    }
}
