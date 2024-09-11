using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaGroup = app.MapGroup("pizza");

            pizzaGroup.MapGet("/getpizzas", GetPizzas);
            pizzaGroup.MapGet("/getorders", GetOrders);
            pizzaGroup.MapGet("/getcustomers", GetCustomers);
            pizzaGroup.MapGet("/getcustomer/{id}", GetCustomer);
            pizzaGroup.MapGet("/getpizza/{id}", GetPizza);
            pizzaGroup.MapGet("/getorders/{id}", GetOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            var pizzas = await repository.GetPizzas();
            if(pizzas == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(pizzas);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrders(IRepository repository)
        {
            var orders = await repository.GetOrders();
            if (orders == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(orders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            var customers = await repository.GetCustomers();
            if (customers == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(customers);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomer(IRepository repository, int id)
        {
            var customer = await repository.GetCustomerById(id);
            if (customer == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(customer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizza(IRepository repository, int id)
        {
            var pizza = await repository.GetPizzaById(id);
            if (pizza == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(pizza);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrder(IRepository repository, int id)
        {
            var order = await repository.GetOrderById(id);
            if (order == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(order);
        }

    }
}
