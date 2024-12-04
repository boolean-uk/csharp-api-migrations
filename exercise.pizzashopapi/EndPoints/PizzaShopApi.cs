using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var customers = app.MapGroup("/customers");
            var pizzas = app.MapGroup("/pizzas");
            var orders = app.MapGroup("/orders");

            customers.MapGet("/", GetCustomers);
            customers.MapGet("/{id}", GetACustomer);
            customers.MapPost("/", AddCustomer);
            customers.MapPut("/{id}", EditCustomer);
            customers.MapDelete("/{id}", DeleteCustomer);

            pizzas.MapGet("/", GetPizzas);
            pizzas.MapGet("/{id}", GetAPizza);
            pizzas.MapPost("/", AddPizza);
            pizzas.MapPut("/{id}", EditPizza);
            pizzas.MapDelete("/{id}", DeletePizza);

            orders.MapGet("/", GetOrders);
            orders.MapGet("/{id}", GetAnOrder);
            orders.MapPost("/", AddOrder);
            orders.MapPut("/{id}", EditOrder);
            orders.MapDelete("/{id}", DeleteOrder);
            orders.MapPut("/changestatus/{id}", ChangeOrderStatus);
            orders.MapGet("/timeleft/{id}", GetOrderTime);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult>ChangeOrderStatus(IRepository repository, int pizzaId, int customerId, bool IsDelivered)
        {
            try
            {
                var order = await repository.ChangeOrderStatus(pizzaId, customerId);
                return order != null ? TypedResults.Ok("Order status: " + DTOConverter.DTOOrderConvert(order).IsDelivered) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> GetOrderTime(IRepository repository, int pizzaId, int customerId)
        {
            try
            {
                var order = await repository.GetAnOrder(pizzaId, customerId);
                var timeNow = DateTime.UtcNow;
                var timeDifference = timeNow.Subtract(order.StartTime).TotalMinutes;

                if (timeDifference < 3)
                {
                    return TypedResults.Ok("Pizza is being preppared");
                } else if (3 < timeDifference && timeDifference < 15)
                {
                    return TypedResults.Ok("Pizza is in the oven");
                }


                return TypedResults.Ok("Pizza is on its way"); ;
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
        }

        /// <summary>
        /// Not implemented, the det, det all and add are implemented. This har been done as I feel it demonstrates the task implementation
        /// while balancing the workload. Let me know if you whish to have all functions implemented.
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> EditOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> AddOrder(IRepository repository, int pizzaId, int customerId)
        {
            try
            {
                 var order = await repository.AddOrder(pizzaId, customerId);
                 return order != null ? TypedResults.Ok(DTOConverter.DTOOrderConvert(order)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetAnOrder(IRepository repository, int pizzaId, int customerId)
        {
            try
            {
                var order = await repository.GetAnOrder(pizzaId, customerId);
                return order != null ? TypedResults.Ok(DTOConverter.DTOOrderConvert(order)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetOrders(IRepository repository)
        {
            try
            {
                var orders = await repository.GetOrders();
                return orders != null ? TypedResults.Ok(DTOConverter.DTOListConvert(orders)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeletePizza(IRepository repository)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> EditPizza(IRepository repository)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> AddPizza(IRepository repository, int id, string name, int price)
        {
            try
            {
                var pizza = await repository.AddPizza(id, name, price);
                return pizza != null ? TypedResults.Ok(DTOConverter.DTOPizzaConvert(pizza)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetAPizza(IRepository repository, int id)
        {
            try
            {
                var pizza = await repository.GetAPizza(id);
                return pizza != null ? TypedResults.Ok(DTOConverter.DTOPizzaConvert(pizza)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetPizzas(IRepository repository)
        {
            try
            {
                var pizzas = await repository.GetPizzas();
                return pizzas != null ? TypedResults.Ok(DTOConverter.DTOListConvert(pizzas)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> EditCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> AddCustomer(IRepository repository, int id, string name)
        {
            try
            {
                var customer = await repository.AddCusomer(id, name);
                return customer != null ? TypedResults.Ok(DTOConverter.DTOCustomerConvert(customer)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetACustomer(IRepository repository, int id)
        {
            try
            {
                var customer = await repository.GetACusomer(id);
                return customer != null ? TypedResults.Ok(DTOConverter.DTOCustomerConvert(customer)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetCustomers(IRepository repository)
        {
            try
            {
                var customers = await repository.GetCusomers();
                return customers != null ? TypedResults.Ok(DTOConverter.DTOListConvert(customers)) : TypedResults.NotFound("NotFound");
            }
            catch (Exception ex)
            {
                using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = factory.CreateLogger("Errors");
                logger.LogInformation(ex.ToString());

                return TypedResults.BadRequest("Bad Request");
            }
        }
    }
}
