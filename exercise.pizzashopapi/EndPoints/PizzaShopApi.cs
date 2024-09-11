using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Models.DTO;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzashop = app.MapGroup("/pizzashop");
            pizzashop.MapGet("/getorders", GetOrders);
            pizzashop.MapGet("/getordersbyid/{id}", GetOrder);
            pizzashop.MapGet("/getordersbycustomer/{id}", GetOrdersByCustomer);
            pizzashop.MapPost("/createorder", CreateOrder);
            pizzashop.MapPut("/deliverorder/{id}", DeliverOrder);

            pizzashop.MapGet("/getpizzas", GetPizzas);
            pizzashop.MapGet("/getpizzabyid/{id}", GetPizza);

            pizzashop.MapGet("/getcustomers", GetCustomers);
            pizzashop.MapGet("/getcustomers/{id}", GetCustomer);
            
        }

        // Orders

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetOrders(IRepository repository)
        {
            IEnumerable<Order> response = await repository.GetOrders();
            return TypedResults.Ok(DTOGenerator.GetOrderDTOs(response));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetOrder(IRepository repository, int id)
        {
            Order response = await repository.GetOrder(id);
            return response != null ? TypedResults.Ok(DTOGenerator.GetOrderDTO(response)) : TypedResults.NotFound("Order not found");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetOrdersByCustomer(IRepository repository, int id)
        {
            IEnumerable<Order> response = await repository.GetOrdersByCustomer(id);
            return TypedResults.Ok(DTOGenerator.GetOrderDTOs(response));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreateOrder(IRepository repository, NewOrder newOrder)
        {
            Order order = await repository.CreateOrder(newOrder);
            return order != null ? TypedResults.Created("/", DTOGenerator.GetOrderDTO(order)) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeliverOrder(IRepository repository, int id)
        {
            Order order = await repository.DeliverOrder(id);
            return order != null ? TypedResults.Created("/", DTOGenerator.GetOrderDTO(order)) : TypedResults.NotFound("Order not found");
        }

        // Pizzas

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPizzas(IRepository repository)
        {
            IEnumerable<Pizza> response = await repository.GetPizzas();
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetPizza(IRepository repository, int id)
        {
            Pizza response = await repository.GetPizza(id);
            return response != null ? TypedResults.Ok(response) : TypedResults.NotFound("Pizza not found");
        }

        // Customers
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetCustomers(IRepository repository)
        {
            IEnumerable<Customer> customers = await repository.GetCustomers();
            return TypedResults.Ok(DTOGenerator.GetCustomerDTOs(customers));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetCustomer(IRepository repository, int id)
        {
            Customer customer = await repository.GetCustomer(id);
            return customer != null ? TypedResults.Ok(DTOGenerator.GetCustomerDTO(customer)) : TypedResults.NotFound("Customer not found");
        }
    }
}
