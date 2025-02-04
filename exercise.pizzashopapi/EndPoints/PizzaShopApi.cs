using System.Linq;
using System.Threading.Tasks;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            app.MapGet("/Customers", GetCustomers);
            app.MapGet("/Customers/{id}", GetCustomer);
            app.MapPost("/Customers", AddCustomer);


            app.MapGet("/DeliveryDrivers", GetDeliveryDrivers);
            app.MapGet("/DeliveryDrivers/{id}", GetDeliveryDriver);
            app.MapPost("/DeliveryDrivers", AddDeliveryDriver);

            app.MapGet("/Orders", GetOrders);
            app.MapGet("/OrdersByCustomer/{id}", GetOrdersByCustomer);
            app.MapGet("/OrdersByDriver/{id}", GetOrdersByDeliveryDriver);
            app.MapPost("/Orders", AddOrder);

            app.MapGet("/pizzas", GetPizzas);
            app.MapPost("/pizzas", AddPizza);

            app.MapGet("/toppings", GetToppings);
            app.MapPost("/toppings", AddTopping);
        }

        public static async Task<IResult> GetCustomers(IRepository repo)
        {
            var result = await repo.GetCustomers();

            return TypedResults.Ok(result.Select(c => c.GetDTO()));
        }
        public static async Task<IResult> GetCustomer(IRepository repo, int id)
        {
            var result = await repo.GetCustomerById(id);
            return TypedResults.Ok(result.GetDTO());
        }

        public static async Task<IResult> AddCustomer(IRepository repo, CustomerDTOPost customer)
        {
            Customer customer1 = new Customer
            {
                Name = customer.Name,
            };
            await repo.AddCustomer(customer1);
            return TypedResults.Ok(customer1);
        }

        public static async Task<IResult> GetDeliveryDrivers(IRepository repo)
        {
            var result = await repo.GetDeliveryDrivers();
            return TypedResults.Ok(result.Select(o => o.ToDTO()));
        }

        public static async Task<IResult> GetDeliveryDriver(IRepository repo, int id)
        {
            var result = await repo.GetDeliveryDriver(id);
            return TypedResults.Ok(result.ToDTO());
        }
        public static async Task<IResult> AddDeliveryDriver(IRepository repo, DeliveryDriverPost deliveryDriver)
        {
            DeliveryDriver driver = new DeliveryDriver
            {
                Name = deliveryDriver.Name
            };

            await repo.AddDeliveryDriver(driver);
            return TypedResults.Ok(driver);
        }

        public static async Task<IResult> GetOrders(IRepository repo)
        {
            var result = await repo.GetOrders();

            return TypedResults.Ok(result.Select(c => c.ToGetDto()));
        }
        public static async Task<IResult> GetOrdersByCustomer(IRepository repo, int id)
        {
            var result = await repo.GetOrdersByCustomer(id);

            return TypedResults.Ok(result.Select(c => c.ToGetDto()));
        }
        public static async Task<IResult> GetOrdersByDeliveryDriver(IRepository repo, int id)
        {
            var result = await repo.GetOrdersByDeliveryDriver(id);

            return TypedResults.Ok(result.Select(c => c.ToGetDto()));
        }
        public static async Task<IResult> AddOrder(IRepository repo, OrderDTOPost order)
        {
            Order order1 = new Order
            {
                CustomerId = order.CustomerId,
                PizzaId = order.PizzaId,
                DeliveryDriverId = order.DeliveryDriverId
            };
            await repo.AddOrder(order1);
            return TypedResults.Ok(order1);
        }

        public static async Task<IResult> GetPizzas(IRepository repo)
        {
            var result = await repo.GetPizzas();
            return TypedResults.Ok(result);
        }

        public static async Task<IResult> AddPizza(IRepository repo, PizzaPost model)
        {
            Pizza pizza = new Pizza
            {
                Name = model.Name,
                Price = model.Price
            };
            await repo.AddPizza(pizza);
            return TypedResults.Ok(pizza);
        }

        public static async Task<IResult> GetToppings(IRepository repo)
        {
            var result = await repo.GetToppings();
            return TypedResults.Ok(result);
        }

        public static async Task<IResult> AddTopping(IRepository repo, ToppingPost model)
        {
            Topping topping = new Topping
            {
                Name = model.Name
            };
            await repo.AddTopping(topping);
            return TypedResults.Ok(topping);
        }
    }
}
