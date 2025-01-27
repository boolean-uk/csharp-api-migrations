using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
                var shop = app.MapGroup("/shop");

            shop.MapGet("/pizzas", GetPizzas);
            shop.MapGet("/customers", GetCustomers);
            shop.MapGet("/orders", GetOrders);
            shop.MapGet("/orders/{customerId}", GetOrdersByCustomerId);
            shop.MapPost("/orders", CreateOrder);
            shop.MapPost("/customers", CreateCustomer);
            shop.MapPost("/pizzas", CreatePizza);
            shop.MapGet("/pizzas/{id}", GetPizzaById);
        }

        private static async Task<IResult> GetPizzas(IRepository<Pizza> repository)
        {
            var pizzas = await repository.Get();
            return TypedResults.Ok(pizzas.Select(p => 
            new PizzaDto() {
                Name = p.Name,
                Price = p.Price
            }));
        }

        private static async Task<IResult> GetCustomers(IRepository<Customer> repository)
        {
            var customers = await repository.Get();
            return TypedResults.Ok(customers.Select(c => 
            new CustomerDto() {
                Name = c.Name
            }));
        }

        private static async Task<IResult> GetOrders(IRepository<Order> repository)
        {
            var orders = await repository.GetWithIncludes(o => o.Customer, o => o.Pizza);
            return TypedResults.Ok(orders.Select(o => new OrderDto()
            {
                Customer = o.Customer.Name,
                Pizza = o.Pizza.Name,
                OrderedAt = o.OrderedAt,
                Price = o.Price,
                IsDelivered = o.IsDelivered
            }));
        }

        private static async Task<IResult> GetOrdersByCustomerId(IRepository<Order> repository, int customerId)
        {
            var orders = await repository.GetWithIncludes(o => o.Customer, o => o.Pizza);
            return TypedResults.Ok(orders.Where(o => o.CustomerId == customerId).Select(o => new OrderDto()
            {
                Customer = o.Customer.Name,
                Pizza = o.Pizza.Name,
                OrderedAt = o.OrderedAt,
                Price = o.Price,
                IsDelivered = o.IsDelivered
            }));
        }

        private static async Task<IResult> CreateOrder(IRepository<Order> repository, IRepository<Pizza> pizzaRepository, CreateOrderDto orderDto)
        {

            PizzaDto pizzaDto = (PizzaDto)await GetPizzaById(pizzaRepository, orderDto.PizzaId);
            var order = new Order()
            {
                CustomerId = orderDto.CustomerId,
                PizzaId = orderDto.PizzaId,
                OrderedAt = DateTime.Now,
                Price = pizzaDto.Price,
                IsDelivered = false
            };
            await repository.Insert(order);
            return TypedResults.Created();
        }

        private static async Task<IResult> CreateCustomer(IRepository<Customer> repository, string customerName)
        {
            var customer = new Customer()
            {
                Name = customerName
            };
            await repository.Insert(customer);
            return TypedResults.Created();
        }

        private static async Task<IResult> CreatePizza(IRepository<Pizza> repository, PizzaDto pizzaDto)
        {
            var pizza = new Pizza()
            {
                Name = pizzaDto.Name,
                Price = pizzaDto.Price
            };
            await repository.Insert(pizza);
            return TypedResults.Created();
        }

        private static async Task<IResult> GetPizzaById(IRepository<Pizza> repository, int id)
        {
            var pizza = await repository.GetById(id);
            if (pizza == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new PizzaDto()
            {
                Name = pizza.Name,
                Price = pizza.Price
            });
        }


    }
}
