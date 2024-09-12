using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.DTO.GetResponse;
using exercise.pizzashopapi.DTO.ViewModels;
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
            pizzashop.MapPost("/orders", CreateOrder);
            pizzashop.MapGet("/pizzas", GetPizzas);
            pizzashop.MapGet("/pizzas/{id}", GetPizza);
            pizzashop.MapPost("/pizzas", CreatePizza);
            pizzashop.MapGet("/customers", GetCustomers);
            pizzashop.MapGet("/customers/{id}", GetACustomer);
            pizzashop.MapPost("/customer", CreateCustomer);


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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateOrder(IRepository repository, OrderPostModel model)
        {

            

            var order = await repository.CreateOrder(new Order() { PizzaId = model.PizzaId, CustomerId = model.CustomerId });

            var customer = await repository.GetCustomerById(order.CustomerId);

            var pizza = await repository.GetPizzaById(order.PizzaId);

        
            PizzaDTO pizzaDTO = new PizzaDTO()
            {
               Id = pizza.Id,
               Name = pizza.Name,
            Price = pizza.Price
            };

            CustomerDTO customerDTO = new CustomerDTO()
            {
                Id = customer.Id, 
                Name = customer.Name,

            };

            OrderDTO orderDTO = new OrderDTO()
            {
                Pizza = pizzaDTO,
                Customer = customerDTO
                

            };

            return TypedResults.Ok(orderDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePizza(IRepository repository, PizzaPostModel model)
        {

            var pizza = await repository.CreatePizza(new Pizza() { Name = model.Name, Price = model.Price });


            var result = await repository.GetPizzaById(pizza.Id);

        
            PizzaDTO pizzaDTO = new PizzaDTO()
            {
               Id = pizza.Id,
               Name = pizza.Name,
            Price = pizza.Price
            };


            return TypedResults.Ok(pizzaDTO);
        }
        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCustomer(IRepository repository, CustomerPostModel model)
        {

            var customer = await repository.CreateCustomer(new Customer() { Name = model.Name });


            var result = await repository.GetCustomerById(customer.Id);

        
            CustomerDTO customerDTO = new CustomerDTO()
            {
               Id = customer.Id,
               Name = customer.Name,
            };


            return TypedResults.Ok(customerDTO);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizza(IRepository repository, int id)
        {
            var results = await repository.GetPizzaById(id);


            PizzaDTO pizzaDTO = new PizzaDTO()
            {
                Id = results.Id,
                Name = results.Name,
                Price = results.Price,


            };
            return TypedResults.Ok(pizzaDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            GetCustomerResponse response = new GetCustomerResponse();

            var result = await repository.GetCustomers();

            foreach (Customer c in result)
            {
                CustomerDTO customerDTO = new CustomerDTO()
                {

                    Id = c.Id,
                    Name = c.Name,

                };

                response.Customers.Add(customerDTO);
            }

            return TypedResults.Ok(response.Customers);

        }
    }
}
