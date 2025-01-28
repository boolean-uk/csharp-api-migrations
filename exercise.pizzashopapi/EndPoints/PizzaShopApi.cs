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
            var shopGroup = app.MapGroup("PizzaShop");

            shopGroup.MapGet("/Customers", GetCustomers);
            shopGroup.MapGet("/Customer", GetCustomer);

            shopGroup.MapGet("/Pizzas", GetPizzas);
            shopGroup.MapGet("/Pizza", GetPizza);

            shopGroup.MapGet("/Orders", GetOrders);
            shopGroup.MapGet("/OrderbyPizza", GetOrderByPizza);
            shopGroup.MapGet("/OrderbyCustomer", GetOrderByCustomer);

        }

        private static async Task<IResult> GetOrderByCustomer(IRepository repository, int id)
        {
            var customerorders = await repository.GetOrdersByCustomer(id);
            var customerordersDtos = customerorders.Select(o => new OrderDTO
            {

                PizzaName = o.Pizza.Name,
                CustomerName = o.Customer.Name
            }).ToList();

            return TypedResults.Ok(customerordersDtos);
        }

        private static async Task<IResult> GetOrderByPizza(IRepository repository, int id )
        {
            var pizzaorders = await repository.GetOrdersByPizza(id);
            var pizzaordersDtos = pizzaorders.Select(o => new OrderDTO
            {
               
                PizzaName = o.Pizza.Name,
                CustomerName = o.Customer.Name
            }).ToList();

            return TypedResults.Ok(pizzaordersDtos);

        }

        private static async Task<IResult> GetPizza(IRepository repository, int id)
        {
            var pizza = await repository.GetPizzaById(id);

            PizzaDTO dto = new PizzaDTO();
            dto.Id = id;
            dto.Name = pizza.Name;



            return TypedResults.Ok(dto);
        }

        private static async Task<IResult> GetCustomer(IRepository repository, int id)
        {
            var customer = await repository.GetCustomerById(id);
            
            CustomerDTO dto = new CustomerDTO();
            dto.Id = id;
            dto.Name = customer.Name;



            return TypedResults.Ok(dto);
        }

        private static async Task<IResult> GetOrders(IRepository repository)
        {
            var orders = await repository.GetOrders();

            var orderDtos = orders.Select(o => new OrderDTO
            {
               
                CustomerName = o.Customer.Name,
                PizzaName = o.Pizza.Name
            }).ToList();

            return TypedResults.Ok(orderDtos);



        }

        private static async Task<IResult> GetPizzas(IRepository repository)
        {
            var pizzas = await repository.GetPizzas();

            var pizzasDtos = pizzas.Select(p => new PizzaDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return TypedResults.Ok(pizzasDtos);



        }

        private static async Task<IResult> GetCustomers(IRepository repository)
        {
            var customers = await repository.GetCustomers();

            var customerDtos = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();


            return TypedResults.Ok(customerDtos);
        }
    }
}
