using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.DTO.Responses;
using exercise.pizzashopapi.DTO.ViewModel;
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
            pizzashop.MapGet("/orders/{id}", GetOrdersByCustomerId);
            pizzashop.MapPost("/create/orders", CreateOrder);
            pizzashop.MapGet("/pizzas", GetPizzas);
            pizzashop.MapGet("/pizzas/{id}", GetPizzaById);
            pizzashop.MapPost("/create/pizzas", CreatePizza);
            pizzashop.MapGet("/customers/{id}", GetCustomerById);
            pizzashop.MapPost("/create/customers", CreateCustomer);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCustomer(IRepository repository, CustomerPostModel model)
        {
            Customer newCustomer = new Customer()
            {
                Name = model.Name
            };

            var creatingCustomer = await repository.CreateCustomer(newCustomer);
            var createdCustomer = await repository.GetCustomerById(creatingCustomer.Id);

            CustomerDTOWithoutOrders customerDTO = new CustomerDTOWithoutOrders() 
            {
                Id = createdCustomer.Id,
                Name = createdCustomer.Name
            };

            return TypedResults.Ok(customerDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateOrder(IRepository repository, OrderPostModel model)
        {
            Order newOrder = new Order() 
            {
                PizzaID = model.PizzaID,
                CustomerID = model.CustomerID
            };

            var creatingOrder = await repository.CreateOrder(newOrder);
            var createdOrder = await repository.GetOrderByIds(creatingOrder.PizzaID, creatingOrder.CustomerID);

            OrderDTO orderDTO = new OrderDTO() 
            {
                Pizza = createdOrder.Pizza,
                Customer = new CustomerDTOWithoutOrders() 
                {
                    Id = createdOrder.Customer.Id,
                    Name = createdOrder.Customer.Name
                }
            };

            return TypedResults.Ok(orderDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePizza(IRepository repository, PizzaPostModel model)
        {
            Pizza newPizza = new Pizza() 
            {
                Name = model.Name,
                Price = model.Price
            };

            var creatingPizza = await repository.CreatePizza(newPizza);
            var createdPizza = await repository.GetPizzaById(creatingPizza.Id);

            return TypedResults.Ok(createdPizza);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzaById(IRepository repository, int id)
        {
            var target = await repository.GetPizzaById(id);

            return TypedResults.Ok(target);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomerById(IRepository repository, int id)
        {
            var target = await repository.GetCustomerById(id);

            SingleCustomerDTOWithOrders customerDTO = new SingleCustomerDTOWithOrders() 
            {
                Id = target.Id,
                Name = target.Name
            };

            foreach (Order order in target.Orders) 
            {
                CustomerOrdersDTO orderDTO = new CustomerOrdersDTO() 
                {
                    Pizza = order.Pizza,
                };

                customerDTO.Orders.Add(orderDTO);
            }

            return TypedResults.Ok(customerDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository repository)
        {
            GetAllOrdersResponse response = new GetAllOrdersResponse();
            var orders = await repository.GetOrders();

            foreach (Order order in orders)
            {
                OrderDTO orderDTO = new OrderDTO()
                {
                    Customer = new CustomerDTOWithoutOrders()
                    {
                        Id = order.Customer.Id,
                        Name = order.Customer.Name
                    },
                    Pizza = order.Pizza
                };

                response.Orders.Add(orderDTO);
            }

            return TypedResults.Ok(response.Orders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByCustomerId(IRepository repository, int id)
        {
            GetAllOrdersResponse response = new GetAllOrdersResponse();
            var orders = await repository.GetOrdersByCustomer(id);

            foreach (Order order in orders)
            {
                OrderDTO orderDTO = new OrderDTO()
                {
                    Customer = new CustomerDTOWithoutOrders() 
                    { 
                        Id = order.Customer.Id, 
                        Name = order.Customer.Name 
                    },

                    Pizza = order.Pizza
                };

                response.Orders.Add(orderDTO);
            }

            return TypedResults.Ok(response.Orders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPizzas());
        }
    }
}
