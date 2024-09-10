using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class BobsPizzaShopAPI
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var bobsGroup = app.MapGroup("BobsPizza");

            bobsGroup.MapGet("/orderByCustomerId/{id}", GetOrdersByCustomerId);
            bobsGroup.MapGet("/orders", GetOrders);
            bobsGroup.MapGet("/orderById/{id}", GetOrderById);
            bobsGroup.MapGet("/customers", GetCustomers);
            bobsGroup.MapGet("/customerById/{id}", GetCustomerById);
            bobsGroup.MapGet("/pizzaById/{id}", GetPizzaById);
            bobsGroup.MapGet("/pizzas", GetPizzas);
            bobsGroup.MapPost("/CreatePizza/{name}", AddPizza);
            bobsGroup.MapPost("/CreateOrder/{customerId, pizzaId}", AddOrder);
            bobsGroup.MapPost("/CreateCustomer/{name}", AddCustomer);
        }

        private static async Task AddCustomer(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task AddOrder(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task AddPizza(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task GetPizzas(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task GetPizzaById(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task GetCustomerById(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task GetCustomers(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task GetOrderById(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task GetOrders(IRepository repository)
        {
            throw new NotImplementedException();
        }

        private static async Task GetOrdersByCustomerId(IRepository repository)
        {
            throw new NotImplementedException();
        }
    }
}
