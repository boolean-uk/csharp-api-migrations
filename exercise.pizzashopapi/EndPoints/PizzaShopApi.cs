using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            app.MapGet("/pizza", GetAllPizzas);
            app.MapGet("/pizza/{id}", GetPizzaById);
            app.MapPost("/pizza", AddPizza);
            app.MapPost("/pizza/{id}", AddToppingToPizza);
            app.MapPut("/pizza/{id}", UpdatePizza);
            app.MapDelete("/pizza/{id}", DeletePizza);

            app.MapGet("/customers", GetAllCustomers);
            app.MapGet("/customers/{id}", GetCustomerById);
            app.MapPost("/customers", AddCustomer);
            app.MapPut("/customers/{id}", UpdateCustomer);
            app.MapDelete("/customers/{id}", DeleteCustomer);

            app.MapGet("/orders", GetAllOrders);
            app.MapGet("/orders/{id}", GetOrderById);
            app.MapGet("/orders/customer/{id}", GetOrderByCustomerId);
            app.MapPost("/orders", AddOrder);
            app.MapPut("/orders/{id}", UpdateOrder);
            app.MapDelete("/orders/{id}", DeleteOrder);

            //app.MapGet("/toppings", GetAllToppings);
            //app.MapGet("/toppings/{id}", GetToppingById);
            //app.MapPost("/toppings", AddTopping);

            app.MapPut("/orders/{orderId}/driver/{driverId}", AddDriverToOrder);
            app.MapPost("/drivers", AddDriver);
            app.MapGet("/drivers", GetAllDrivers);
            app.MapGet("/drivers/{id}/orders", GetAllOrdersForDriverID);
        }


        private static async Task<IResult> AddToppingToPizza(IRepository repository, int pizzaId, int toppingId)
        {

            Pizza pizza = await repository.AddToppingToPizza(pizzaId, toppingId);
            return Results.Ok(pizza);
        }

        private static async Task<IResult> AddDriverToOrder(IRepository repository, int orderId, int driverId)
        {
            Order order = await repository.AddDriverToOrder(orderId, driverId);
            return Results.Ok(order);
        }

        private static async Task<IResult> AddDriver(IRepository repository, DriverDTO driver)
        {
            Driver driver1 = new Driver
            {
                Name = driver.Name
            };
            await repository.AddDriver(driver1);

            return Results.Created($"/pizza/{driver1.Id}", driver1);
        }

        private static async Task<IResult> GetAllDrivers(IRepository repository)
        {
            IEnumerable<Driver> drivers = await repository.GetAllDrivers();
            return Results.Ok(drivers);
        }

        private static async Task<IResult> GetAllOrdersForDriverID(IRepository repository, int driverId)
        {
            IEnumerable<Order> orders = await repository.GetAllOrdersForDriverID(driverId);
            return Results.Ok(orders);
        }

        private static async Task<IResult>DeleteOrder(IRepository repository, int id)
        {
            return Results.Ok(await repository.DeleteOrder(id));
        }

        private static async Task<IResult>UpdateOrder(IRepository repository, int id, OrderDTO orderDTO)
        {
            Order order = await repository.GetOrder(id);
            order.PizzaId = orderDTO.PizzaId;
            order.CustomerId = orderDTO.CustomerId;
            order.Date = DateTime.Now;

            await repository.UpdateOrder(id, order);
            return Results.Ok(order);
        }

        private static async Task<IResult> AddOrder(IRepository repository, OrderDTO order)
        {
            Order order1 = new Order
            {
                CustomerId = order.CustomerId,
                PizzaId = order.PizzaId,
                Date = DateTime.Now
            };
            await repository.AddOrder(order1);
            return Results.Created($"/pizza/{order1.Id}", order1);
        }

        private static async Task<IResult>GetOrderByCustomerId(IRepository repository, int id)
        {
            IEnumerable<Order> orders = await repository.GetOrdersByCustomer(id);
            return Results.Ok(orders);
        }

        private static async Task<IResult> GetOrderById(IRepository repository, int id)
        {
            Order order = await repository.GetOrder(id);
            return Results.Ok(order);
        }

        private static async Task<IResult>GetAllOrders(IRepository repository)
        {
            IEnumerable<Order> orders = await repository.GetOrders();
            return Results.Ok(orders);
        }

        private static async Task<IResult>DeleteCustomer(IRepository repository, int id)
        {
            return Results.Ok(await repository.DeleteCustomer(id));
        }

        private static async Task<IResult>UpdateCustomer(IRepository repository, int id, CustomerDTO customer)
        {
            Customer customer1 = await repository.GetCustomer(id);

            customer1.Name = customer.Name;
            await repository.UpdateCustomer(id, customer1);
            return Results.Ok(customer1);
        }

        private static async Task<IResult> AddCustomer(IRepository repository, CustomerDTO customer)
        {
            Customer customer1 = new Customer
            {
                Name = customer.Name,
            };
            await repository.AddCustomer(customer1);
            return Results.Created($"/pizza/{customer1.Id}", customer1);
        }

        private static async Task<IResult>GetCustomerById(IRepository repository, int id)
        {
            Customer customer = await repository.GetCustomer(id);
            return Results.Ok(customer);
        }

        private static async Task<IResult> GetAllCustomers(IRepository repository)
        {
            IEnumerable<Customer> customers = await repository.GetCustomers();
            return Results.Ok(customers);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult>UpdatePizza(IRepository repository, int id, PizzaDTONoTopping pizzaDTO)
        {
            Pizza pizza = await repository.GetPizza(id);

            pizza.Name = pizzaDTO.Name;
            pizza.Price = pizzaDTO.Price;
            await repository.UpdatePizza(id, pizza);


            return Results.Ok(pizza);
        }

        private static async Task<IResult>DeletePizza(IRepository repository, int id)
        {
            return Results.Ok(await repository.DeletePizza(id));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddPizza(IRepository repository, PizzaDTONoTopping pizzaDTO)
        {
            Pizza pizza1 = new Pizza
            {
                Name = pizzaDTO.Name,
                Price = pizzaDTO.Price
            };
            await repository.AddPizza(pizza1);
            return Results.Created($"/pizza/{pizza1.Id}", pizza1);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetPizzaById(IRepository repository, int id)
        {
            Pizza pizza = await repository.GetPizza(id);
            return Results.Ok(pizza);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllPizzas(IRepository repository)
        {
            IEnumerable<Pizza> pizzas = await repository.GetPizzas();
            return Results.Ok(pizzas);
        }

    }
}
