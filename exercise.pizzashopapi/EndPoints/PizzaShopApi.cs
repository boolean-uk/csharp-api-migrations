using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var shop = app.MapGroup("");
            shop.MapGet("/orders", GetOrders);
            shop.MapGet("/ordersbycustomer/{id}", GetOrdersByCustomer);
            shop.MapGet("/ordersbypizzas/{id}", GetOrdersByPizza);
            shop.MapPost("/orders", CreateOrder);
            shop.MapPut("/ordersbycustomer/{id}", UpdateCustomerOrder);

            shop.MapGet("/pizzas", GetPizzas);
            shop.MapGet("/pizzas/{id}", GetPizza);
            shop.MapPost("/pizzas", CreatePizza);

            shop.MapGet("/customers", GetCustomers);
            shop.MapGet("/customers/{id}", GetCustomer);
            shop.MapPost("/customers", CreateCustomer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> repository)
        {
            var result = await repository.GetAll(["Customer", "Pizza"]);
            var resultDTO = new List<OrderDTO>();
            foreach (var res in result)
            {
                resultDTO.Add(new OrderDTO() { Customer = res.Customer, Pizza = res.Pizza, Status = res.Status.ToString() });
            }
            return TypedResults.Ok(resultDTO);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByCustomer(IRepository<Order> repository, int id)
        {
            var result = await repository.GetAll(["Customer", "Pizza"], o => o.CustomerId == id);
            var resultDTO = new List<OrderDTO>();
            foreach (var res in result)
            {
                resultDTO.Add(new OrderDTO() { Customer = res.Customer, Pizza = res.Pizza, Status = res.Status.ToString() });
            }
            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByPizza(IRepository<Order> repository, int id)
        {
            var result = await repository.GetAll(["Customer", "Pizza"], o => o.PizzaId == id);
            var resultDTO = new List<OrderDTO>();
            foreach (var res in result)
            {
                resultDTO.Add(new OrderDTO() { Customer = res.Customer, Pizza = res.Pizza, Status = res.Status.ToString() });
            }
            return TypedResults.Ok(resultDTO);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateOrder(IRepository<Order> repository, OrderView view)
        {
            var result = await repository.Create(["Customer", "Pizza"], new Order() { CustomerId = view.CustomerId, PizzaId = view.PizzaId, Status = (PizzaStatus) 1 });
            var resultDTO = new OrderDTO() { Customer = result.Customer, Pizza = result.Pizza, Status = result.Status.ToString() };
            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCustomerOrder(IRepository<Order> repository, int id,  OrderUpdateView view)
        {
            var result = await repository.Update(["Customer", "Pizza"],
                                                 new Order() { CustomerId = id, PizzaId = view.PizzaId, Status = (PizzaStatus)view.Status });
            var resultDTO = new OrderDTO() { Customer = result.Customer, Pizza = result.Pizza, Status = result.Status.ToString() };
            return TypedResults.Ok(resultDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repository)
        {
            var result = await repository.GetAll([]);
            var resultDTO = new List<PizzaDTO>();
            foreach (var res in result)
            {
                resultDTO.Add(new PizzaDTO() { Name = res.Name, Price = res.Price });
            }
            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizza(IRepository<Pizza> repository, int id)
        {
            var result = await repository.Get([], o => o.Id == id);
            var resultDTO = new PizzaDTO() { Name = result.Name, Price = result.Price };
            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePizza(IRepository<Pizza> repository, PizzaView view)
        {
            var result = await repository.Create([], new Pizza() { Name = view.Name, Price = view.Price });
            var resultDTO = new PizzaDTO() { Name = result.Name, Price = result.Price };
            return TypedResults.Ok(resultDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository<Customer> repository)
        {
            var result = await repository.GetAll([]);
            var resultDTO = new List<CustomerDTO>();
            foreach (var res in result)
            {
                resultDTO.Add(new CustomerDTO() { Name = res.Name });
            }
            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomer(IRepository<Customer> repository, int id)
        {
            var result = await repository.Get([], o => o.Id == id);
            var resultDTO = new CustomerDTO() { Name = result.Name };
            return TypedResults.Ok(resultDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCustomer(IRepository<Customer> repository, CustomerView view)
        {
            var result = await repository.Create([], new Customer() { Name = view.Name });
            var resultDTO = new CustomerDTO() { Name = result.Name };
            return TypedResults.Ok(resultDTO);
        }
    }
}
