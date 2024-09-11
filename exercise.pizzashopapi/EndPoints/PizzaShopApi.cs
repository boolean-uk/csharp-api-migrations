using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.DTOs.Customer;
using exercise.pizzashopapi.DTOs.Order;
using exercise.pizzashopapi.DTOs.Pizza;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzashop = app.MapGroup("pizzashop");
            pizzashop.MapGet("/pizzas", GetPizzas);
            pizzashop.MapGet("/pizzas/{id}", GetPizzaById);
            pizzashop.MapPost("/addpizza/{model}", AddPizza);
            pizzashop.MapGet("/customers", GetCustomers);
            pizzashop.MapGet("/customers/{id}", GetCustomerById);
            pizzashop.MapPost("/addcustomer/{model}", AddCustomer);
            pizzashop.MapGet("/orders", GetOrders);
            pizzashop.MapGet("/orders/{customerid}", GetOrderByCustomer);
            pizzashop.MapPost("/createOrder/{model}", CreateOrder);
            pizzashop.MapGet("/orderIsDelivered/{id}", DeliverOrder);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repository)
        {
            Payload<List<Pizza>> payload = new Payload<List<Pizza>>();
            var pizza = await repository.Get();
            payload.Data = pizza.ToList();

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzaById(IRepository<Pizza> repository, int id)
        {
            Payload<Pizza> payload = new Payload<Pizza>();
            var pizza = await repository.GetById(id);
            payload.Data = pizza;

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPizza(IRepository<Pizza> repository, PizzaPostModel model)
        {
            var checkPizza = await repository.Get();

            if (checkPizza.Any(x => x.Name == model.PizzaName))
            {
                return TypedResults.BadRequest("Pizza already exist");
            }
            else
            {
                Pizza pizza = new Pizza() { Name = model.PizzaName, Price = model.Price };
                var newPizza = await repository.Create(pizza);
                Payload<Pizza> payload = new Payload<Pizza>();
                payload.Data = newPizza;
                return TypedResults.Ok(payload);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository<Customer> repository)
        {
            Payload<List<Customer>> payload = new Payload<List<Customer>>();
            var customers = await repository.Get();
            payload.Data = customers.ToList();

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomerById(IRepository<Customer> repository, int id)
        {
            Payload<Customer> payload = new Payload<Customer>();
            var customer = await repository.GetById(id);
            payload.Data = customer;

            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddCustomer(IRepository<Customer> repository, CustomerPostModel model)
        {
            var checkCustomer = await repository.Get();

            if (checkCustomer.Any(x => x.Name == model.CustomerName))
            {
                return TypedResults.BadRequest("Customer already exist");
            }
            else
            {
                Customer customer = new Customer() { Name = model.CustomerName };
                var newCustomer = await repository.Create(customer);
                Payload<Customer> payload = new Payload<Customer>();
                payload.Data = newCustomer;
                return TypedResults.Ok(payload);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> repository)
        {
            Payload<List<Order>> payload = new Payload<List<Order>>();
            var orders = await repository.Get();
            payload.Data = orders.ToList();

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetOrderByCustomer(IRepository<Order> orderRepository, int customerid)
        {
            Payload<Order> payload = new Payload<Order>();

            var orders = await orderRepository.Get();
            var customerOrder = orders.FirstOrDefault(x => x.CustomerId == customerid);

            if (customerOrder != null)
            {
                TimeSpan timeSpent = DateTime.UtcNow - customerOrder.TimeOfOrder;
                if(timeSpent.Minutes <= 3)
                {
                    customerOrder.OrderStatus = Enums.OrderStatus.preparing;
                }
                if(timeSpent.Minutes > 3 && timeSpent.Minutes <= 12)
                {
                    customerOrder.OrderStatus = Enums.OrderStatus.cooking;
                }
                if(timeSpent.Minutes > 12)
                {
                    customerOrder.OrderStatus = Enums.OrderStatus.delivering;
                }

                payload.Data = customerOrder;
                await orderRepository.Save();
                return TypedResults.Ok(payload);
            }
            return TypedResults.BadRequest("No order exists for this customer");

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateOrder(IRepository<Order> repository, IRepository<Customer> custRepo, IRepository<Pizza> pizzarepo, OrderPostModel model)
        {

            var checkOrder = await repository.Get();

            if (checkOrder.Any(x => x.CustomerId == model.CustomerId && x.PizzaId == model.PizzaId))
            {
                return TypedResults.BadRequest("Order already exist");
            }


            Customer customer = await custRepo.GetById(model.CustomerId);
            Pizza pizza = await pizzarepo.GetById(model.PizzaId);

            if (customer != null && pizza != null)
            {
                Order order = new Order() { CustomerId = model.CustomerId, PizzaId = model.PizzaId, OrderStatus = Enums.OrderStatus.preparing };
                var newOrder = await repository.Create(order);
                OrderDTO payload = new OrderDTO() { Customer = customer.Name, Pizza = pizza.Name, Total = pizza.Price, OrderStatus = order.OrderStatus.ToString() };
                return TypedResults.Ok(payload);

            }
            return TypedResults.BadRequest("Customer or pizza does not exist");


        }

        public static async Task<IResult> DeliverOrder(IRepository<Order> orderRepo, IRepository<Customer> custRepo, IRepository<Pizza> pizzaRepo, int id)
        {
            var orders = await orderRepo.Get();
            var customerOrder = orders.FirstOrDefault(x => x.CustomerId == id);

            if (customerOrder != null) 
            {
                
                if (customerOrder.OrderStatus != Enums.OrderStatus.delivering)
                {
                    return TypedResults.BadRequest("Order is not ready");
                }
                customerOrder.OrderStatus = Enums.OrderStatus.delivered;
                await orderRepo.Save();

                Customer customer = await custRepo.GetById(customerOrder.CustomerId);
                Pizza pizza = await pizzaRepo.GetById(customerOrder.PizzaId);
                OrderDTO order = new OrderDTO() { Customer = customer.Name, Pizza = pizza.Name, Total = pizza.Price, OrderStatus = customerOrder.OrderStatus.ToString() };
                
                return TypedResults.Ok(order);
            }
            return TypedResults.BadRequest("No order found");
        }

    }
}
