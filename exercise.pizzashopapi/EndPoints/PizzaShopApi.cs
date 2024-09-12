using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.DTO.GetResponse;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzashop = app.MapGroup("pizzashop");

            pizzashop.MapGet("/orders", GetOrders);
            pizzashop.MapGet("/orders/{id}", GetOrdersByCustomer);
            //pizzashop.MapPost("/orders", CreateOrder);
            pizzashop.MapGet("/pizzas", GetPizzas);
            //   pizzashop.MapGet("/pizzas/{id}", GetAPizza);
            // pizzashop.MapGet("/customers", GetCustomers);
            pizzashop.MapGet("/customers/{id}", GetACustomer);


        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository repository)
        {

            GetOrdersResponse response = new GetOrdersResponse();
            var results = await repository.GetOrders();


            foreach (Order o in results)
            {
                CustomerDTO customerDTO = new CustomerDTO()
                {
                    Id = o.CustomerId,
                    Name = o.Customer.Name
                };


                PizzaDTO pizzaDTO = new PizzaDTO()
                {
                    Id = o.PizzaId,
                    Name = o.Pizza.Name,
                    Price = o.Pizza.Price,
                };

                OrderDTO orderDTO = new OrderDTO()
                {
                    Pizza = pizzaDTO,
                    Customer = customerDTO
                };

                response.Orders.Add(orderDTO);

            }

            return TypedResults.Ok(response.Orders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByCustomer(IRepository repository, int id)
        {
            GetOrdersResponse response = new GetOrdersResponse();

            var results = await repository.GetOrdersByCustomer(id);

            var customer = await repository.GetCustomerById(id);

            CustomerDTO customerDTO = new CustomerDTO()
            {
                Id = customer.Id,
                Name = customer.Name
            };

            foreach (Order o in results)
            {


                PizzaDTO pizzaDTO = new PizzaDTO() { 
                    Id = o.PizzaId, 
                    Name = o.Pizza.Name,
                    Price = o.Pizza.Price,
                };


                OrderDTO orderDTO = new OrderDTO()
                {
                    Customer = customerDTO,
                    Pizza = pizzaDTO
                };

                response.Orders.Add(orderDTO);


            }
                return TypedResults.Ok(response.Orders);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetACustomer(IRepository repository, int id)
        {


            var results = await repository.GetCustomerById(id);

            CustomerDTO customerDTO = new CustomerDTO() {

                Id = id,
                Name = results.Name
                };


            return TypedResults.Ok(customerDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            GetPizzaResponse response = new GetPizzaResponse();
            var results = await repository.GetPizzas();

            foreach (Pizza p in results)
            {
                PizzaDTO pizzaDTO = new PizzaDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                };

                response.Pizzas.Add(pizzaDTO);
            }
            return TypedResults.Ok(response.Pizzas);
        }

    }
}
