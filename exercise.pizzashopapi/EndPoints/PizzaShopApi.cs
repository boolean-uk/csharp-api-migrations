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
            var pizzaGroup = app.MapGroup("pizzashop");

            pizzaGroup.MapGet("/GetOrdersByCustomer", GetOrdersByCustomer);
            pizzaGroup.MapGet("/Orders", GetOrders);
            pizzaGroup.MapGet("/GetPizzas", GetPizzas);
            pizzaGroup.MapGet("/Customers", GetCustomers);
            pizzaGroup.MapGet("/Customer", GetCustomer);


        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByCustomer(IRepository repo, int customerId)
        {
            var orders = await repo.GetOrdersByCustomer(customerId);
            //make it into DTO 
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            orders.ToList().ForEach(x => orderDTOs.Add(new OrderDTO(x)));
            return TypedResults.Ok(orderDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository repo)
        {
            var orders = await repo.GetOrders();
            //make it into DTO 
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            orders.ToList().ForEach(x => orderDTOs.Add(new OrderDTO(x)));
            return TypedResults.Ok(orderDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository repo)
        {
            var pizzas = await repo.GetPizzas();
            List<PizzaDTO> pizzaDTOs = new List<PizzaDTO>();
            pizzas.ToList().ForEach(x => pizzaDTOs.Add(new PizzaDTO(x)));
            return TypedResults.Ok(pizzaDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository repo)
        {
            var customers = await repo.GetCustomers();
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();   
            customers.ToList().ForEach( x => customerDTOs.Add(new CustomerDTO(x)));
            return TypedResults.Ok(customerDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomer(IRepository repo ,int id)
        {
            var customer = await repo.GetCustomer(id);
            return TypedResults.Ok(new CustomerDTO(customer.First()));
        }

    }
}
