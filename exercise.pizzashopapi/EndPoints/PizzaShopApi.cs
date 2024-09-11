using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaShopGroup = app.MapGroup("pizzaShop");

            // ------ Orders ------
            pizzaShopGroup.MapGet("/orders", GetOrders);
            pizzaShopGroup.MapGet("/ordersbycustomer", GetOrdersByCustomer);
            pizzaShopGroup.MapGet("/orders/{id}", GetOrderById);
            pizzaShopGroup.MapPost("/orders", CreateOrder);
            pizzaShopGroup.MapDelete("/orders", DeleteOrder);

            //Task<IEnumerable<Order>> GetOrders();
            //Task<IEnumerable<Order>> GetOrdersByCustomer(int id);
            //Task<Order> GetOrderById(int customerId, int pizzaId);
            //Task<Order> CreateOrder(Order entity);
            //Task<Order> DeleteOrder(int customerId, int pizzaI);

            // ------ Pizzas ------
            pizzaShopGroup.MapGet("/pizzas", GetPizzas);
            pizzaShopGroup.MapGet("/pizzas/{id}", GetPizzaById);
            pizzaShopGroup.MapPost("/pizzas", CreatePizza);
            pizzaShopGroup.MapDelete("/pizzas", DeletePizza);

            //Task<IEnumerable<Pizza>> GetPizzas();
            //Task<Pizza> GetPizzaById(int id);
            //Task<Pizza> CreatePizza(Pizza entity);
            //Task<Pizza> DeletePizza(int id);

            // ------ Customers ------
            pizzaShopGroup.MapGet("/pizzas", GetPizzas);
            pizzaShopGroup.MapGet("/pizzas/{id}", GetPizzaById);
            pizzaShopGroup.MapPost("/pizzas", CreatePizza);
            pizzaShopGroup.MapDelete("/pizzas", DeletePizza);

            //Task<IEnumerable<Customer>> GetCustomers();
            //Task<Customer> GetCustomerById(int id);
            //Task<Customer> CreateCustomer(Customer entity);
            //Task<Customer> DeleteCustomer(int id);
            
    
        }

        // ------ Orders ------
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> GetOrders(IRepository repository)
        {
            var results = await repository.GetOrders();
            List<Order> orders = results.ToList();
            if (orders.Count <= 0)
            {
                return TypedResults.NoContent();
            }

            List<ResponseOrderDTO> responseOrders = new List<ResponseOrderDTO>();

            foreach (Order o in orders)
            {
                responseOrders.Add(CreateResponseOrderDTO(o));
            }

            return TypedResults.Ok(responseOrders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> GetOrdersByCustomer(int id)
        {
            var results = await repository.GetOrders();
            List<Order> orders = results.ToList();
            if (orders.Count <= 0)
            {
                return TypedResults.NoContent();
            }

            List<ResponseOrderDTO> responseOrders = new List<ResponseOrderDTO>();

            foreach (Order o in orders)
            {
                responseOrders.Add(CreateResponseOrderDTO(o));
            }

            return TypedResults.Ok(responseOrders);
        }

        public static ResponseOrderDTO CreateResponseOrderDTO(Order order)
        {
            ResponseOrderDTO responseOrder = new ResponseOrderDTO();
            responseOrder.CustomerId = order.CustomerId;
            responseOrder.CustomerName = order.Customer.Name;
            responseOrder.PizzaId = order.PizzaId;
            responseOrder.PizzaName = order.Pizza.Name;
            responseOrder.CreatedAt = order.CreatedAt;
            responseOrder.OrderStatus = responseOrder.GetOrderStatus(order.CreatedAt);

            return responseOrder;
        }
    }
}
