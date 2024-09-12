using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.DTO.Responses;
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
            pizzashop.MapGet("/pizzas", GetPizzas);
            pizzashop.MapGet("/customers/{id}", GetCustomerById);
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
