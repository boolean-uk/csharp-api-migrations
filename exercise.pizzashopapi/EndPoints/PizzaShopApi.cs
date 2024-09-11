using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizza = app.MapGroup("pizza");
            var customer = app.MapGroup("customer");
            var order = app.MapGroup("order");
            pizza.MapGet("/getpizzas", GetAllPizzas);
            pizza.MapGet("/getpizza/{id}", GetPizza);
            customer.MapGet("/getcustomers", GetAllCustomers);
            customer.MapGet("/getcustomer/{id}", GetCustomer);
            customer.MapPost("/addcustomer", AddCustomer);
            order.MapGet("/getordersbycustomer/{CustomerID}", GetOrdersByCustomer);
            order.MapGet("/getorderbyid/{OrderID}", GetOrdersById);
            order.MapPost("/addorder", AddOrder);

        }

        public static async Task<IResult> GetAllPizzas(IRepository repository)
        {
            List<Pizza> pizzas = await repository.GetAllPizzas();
            return TypedResults.Ok(pizzas);
        }
        public static async Task<IResult> GetPizza(IRepository repository, int id)
        {
            Pizza pizza = await repository.GetPizza(id);
            return TypedResults.Ok(pizza);
        }
        public static async Task<IResult> GetCustomer(IRepository repository, int id)
        {
            Customer customer = await repository.GetCustomer(id);
            return TypedResults.Ok(customer);
        }
        public static async Task<IResult> GetAllCustomers(IRepository repository)
        {
            List<Customer> customers = await repository.GetAllCustomers();
            return TypedResults.Ok(customers);
        }
        public static async Task<IResult> AddCustomer(IRepository repository, Customer customer)
        {
            Customer addedCustomer = await repository.AddCustomer(customer);
            return TypedResults.Ok(addedCustomer);
        }
        public static async Task<IResult> GetOrdersByCustomer(IRepository repository, int CustomerID)
        {
            IEnumerable<Order> orders = await repository.GetOrdersByCustomer(CustomerID);
            return TypedResults.Ok(orders);
        }
        public static async Task<IResult> GetOrdersById(IRepository repository, int OrderID)
        {
            Order order = await repository.GetOrder(OrderID);
            return TypedResults.Ok(order);
        }
        public static async Task<IResult> AddOrder(IRepository repository, Order order)
        {
            Order addedOrder = await repository.AddOrder(order);
            return TypedResults.Ok(addedOrder);
        }
       
    }
}
