using api_cinema_challenge.Models;
using System.ComponentModel.DataAnnotations.Schema;
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
            
            //gets
            pizzaGroup.MapGet("/GetOrdersByCustomer", GetOrdersByCustomer);
            pizzaGroup.MapGet("/Orders", GetOrders);
            pizzaGroup.MapGet("/GetPizzas", GetPizzas);
            pizzaGroup.MapGet("/Customers", GetCustomers);
            pizzaGroup.MapGet("/Customer", GetCustomer);
            //sets
            pizzaGroup.MapPut("/Order/status", SetOrderStatus);
            //creates
            pizzaGroup.MapPost("/neworder", CreateOrder);
            pizzaGroup.MapPost("/newcustomer", CreateCustomer);
            pizzaGroup.MapPost("/newpizza", CreatePizza);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateOrder(IRepository<Order> repo, int customerId, int pizzaId, string status )
        {
            try
            {
                Order order = new Order { status = status , customerId= customerId, pizzaId=pizzaId};
                repo.Insert(order);
                repo.Save();
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePizza(IRepository<Pizza> repo, decimal price, string name)
        {
            try
            {
                Pizza pizza = new Pizza { Price=price, Name=name};
                repo.Insert(pizza);
                repo.Save();
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCustomer(IRepository<Customer> repo, string name)
        {
            try
            {
                Customer customer = new Customer { Name=name               };
                repo.Insert(customer);
                repo.Save();
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> SetOrderStatus(IRepository<Order> repo, int orderId, string status)
        {
            try
            {
                Order order = repo.GetById(orderId);
                order.status = status;
                repo.Save();
                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByCustomer(IRepository<Customer> repo, int customerId)
        {
            Customer customer =  repo.GetById(customerId);
            var orders = customer.Orders.ToList();
            //make it into DTO 
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            orders.ToList().ForEach(x => orderDTOs.Add(new OrderDTO(x)));
            return TypedResults.Ok(orderDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> repo)
        {
            var orders = repo.GetAll();
            //make it into DTO 
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            orders.ToList().ForEach(x => orderDTOs.Add(new OrderDTO(x)));
            return TypedResults.Ok(orderDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repo)
        {
            var pizzas = repo.GetAll();
            List<PizzaDTO> pizzaDTOs = new List<PizzaDTO>();
            pizzas.ToList().ForEach(x => pizzaDTOs.Add(new PizzaDTO(x)));
            return TypedResults.Ok(pizzaDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository<Customer> repo)
        {
            var customers = repo.GetAll();
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();   
            customers.ToList().ForEach( x => customerDTOs.Add(new CustomerDTO(x)));
            return TypedResults.Ok(customerDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomer(IRepository<Customer> repo ,int id)
        {
            var customer = repo.GetById(id);
            return TypedResults.Ok(new CustomerDTO(customer));
        }

    }
}
