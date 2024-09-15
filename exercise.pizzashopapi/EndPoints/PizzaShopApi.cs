using System.Reflection.Metadata.Ecma335;
using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaShopGroup = app.MapGroup("/pizzaShop");
            pizzaShopGroup.MapGet("/orders", GetOrders);
            pizzaShopGroup.MapGet("/orders/{customerId}", GetOrdersByCustomerId);
            pizzaShopGroup.MapPost("/orders", AddOrder);

            pizzaShopGroup.MapGet("/pizzas", GetPizzas);
            pizzaShopGroup.MapGet("/pizzas/{id}", GetPizzaById);
            pizzaShopGroup.MapPost("/pizzas", AddPizza);

            pizzaShopGroup.MapGet("/customers", GetCustomers);
            pizzaShopGroup.MapGet("/customers/{id}", GetCustomerById);
        }


        //ORDERS
       [ProducesResponseType(StatusCodes.Status200OK)]
       public static async Task<IResult> GetOrders(IRepository repository)
        {
            var orders = await repository.GetOrders();

            GetAllResponse<DTOOrder> orderResponse = new GetAllResponse<DTOOrder>();
            foreach (var order in orders) 
            {
               
                orderResponse.Response.Add(_getDtoOrder(order));
            }
            return TypedResults.Ok(orderResponse);
        }

        [Route("/orders/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrdersByCustomerId(IRepository repository, int customerId)
        {
            if (await repository.GetCustomerById(customerId) == null)
            {
                return TypedResults.NotFound(new Message { Information = "Customer does not exist in database  :("});
            }

            var orders = await repository.GetOrdersByCustomerId(customerId);

            GetAllResponse<DTOOrder> orderResponse = new GetAllResponse<DTOOrder>();
            foreach (var order in orders)
            {

                orderResponse.Response.Add(_getDtoOrder(order));
            }
            return TypedResults.Ok(orderResponse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddOrder(IRepository repository, OrderPostModel model)
        {
            try
            {
                if (await repository.GetCustomerById(model.CustomerId) == null)
                {
                    return TypedResults.NotFound(new Message { Information = "Customer does not exist in database  :(" });
                }
                if (await repository.GetPizzaById(model.PizzaId) == null)
                {
                    return TypedResults.NotFound(new Message { Information = "Pizza does not exist in database  :(" });
                }

                Order order = await repository.AddOrder(new Order { CustomerId = model.CustomerId, PizzaId = model.PizzaId, DeliveryAddress = model.DeliveryAddress });
                return TypedResults.Created("", _getDtoOrder(order));
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }



        //PIZZAS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            var pizzas = await repository.GetPizzas();

            GetAllResponse<DTOPizza> pizzaResponse = new GetAllResponse<DTOPizza>();
            foreach (var pizza in pizzas)
            {
                pizzaResponse.Response.Add(new DTOPizza() { ID = pizza.Id, Name = pizza.Name, Price = pizza.Price});
            }
            return TypedResults.Ok(pizzaResponse);
        }

        [Route("/pizzas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzaById(IRepository repository, int id)
        {
            Pizza pizza = await repository.GetPizzaById(id);
            if(pizza == null)
            {
                return TypedResults.NotFound(new Message());
            }
            return TypedResults.Ok(new DTOPizza() { ID = pizza.Id, Name = pizza.Name, Price = pizza.Price });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPizza(IRepository repository, PizzaPostModel model)
        {
            try
            {
                Pizza pizza = await repository.AddPizza(new Pizza() {Name = model.Name, Price = model.Price });
                return TypedResults.Created("", new DTOPizza() { ID = pizza.Id, Name = pizza.Name, Price = pizza.Price });

            }
            catch (Exception ex) 
            { 
                return TypedResults.BadRequest(ex);
            }
        }



        //CUSTOMERS
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            var customers = await repository.GetCustomers();

            GetAllResponse<DTOCustomer> customerResponse = new GetAllResponse<DTOCustomer>();
            foreach (var customer in customers)
            {
                customerResponse.Response.Add(new DTOCustomer() { ID = customer.Id, Name = customer.Name});
            }
            return TypedResults.Ok(customerResponse);
        }

        [Route("/customers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomerById(IRepository repository, int id)
        {
            Customer customer = await repository.GetCustomerById(id);
            if (customer == null)
            {
                return TypedResults.NotFound(new Message());
            }
            return TypedResults.Ok(new DTOCustomer() { ID = customer.Id, Name = customer.Name});
        }





        public static DTOOrder _getDtoOrder(Order order)
        {
            DTOPizza pizza = new DTOPizza() { ID = order.PizzaOnOrder.Id, Name = order.PizzaOnOrder.Name, Price = order.PizzaOnOrder.Price };
            DTOCustomer customer = new DTOCustomer() { ID = order.CustomerOnOrder.Id, Name = order.CustomerOnOrder.Name };
            DTOOrder dtoorder = new DTOOrder() { DeliveryAdcress = order.DeliveryAddress, Customer = customer, Pizza = pizza };
            return dtoorder;
        }
    }
}
