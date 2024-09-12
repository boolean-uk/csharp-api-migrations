using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.DTOs.Customer;
using exercise.pizzashopapi.DTOs.Order;
using exercise.pizzashopapi.DTOs.Pizza;
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
        public static async Task<IResult> GetOrders(IRepository<Order> orderRepo, IRepository<Customer> custRepo, IRepository<Pizza> pizzaRepo)
        {

            GetOrdersResponse response = new GetOrdersResponse();
            var orders = await orderRepo.Get();

            foreach (Order ord in orders)
            {
                OrderDTO orderDTO = new OrderDTO();
                Customer cust = await custRepo.GetById(ord.CustomerId);
                Pizza pizza = await pizzaRepo.GetById(ord.PizzaId);
                orderDTO.Customer = cust.Name;
                orderDTO.Pizza = pizza.Name;
                orderDTO.Total = pizza.Price;

                if (ord.OrderStatus != Enums.OrderStatus.delivered)
                {
                    TimeSpan timeSpent = DateTime.UtcNow - ord.TimeOfOrder;
                    if (timeSpent.Minutes <= 3)
                    {
                        ord.OrderStatus = Enums.OrderStatus.preparing;

                    }
                    if (timeSpent.Minutes > 3 && timeSpent.Minutes <= 12)
                    {
                        ord.OrderStatus = Enums.OrderStatus.cooking;

                    }
                    if (timeSpent.Minutes > 12)
                    {
                        ord.OrderStatus = Enums.OrderStatus.delivering;

                    }

                    orderDTO.OrderStatus = ord.OrderStatus.ToString();
                }

                orderDTO.OrderStatus = ord.OrderStatus.ToString();

                response.Orders.Add(orderDTO);

            }
            await orderRepo.Save();
            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetOrderByCustomer(IRepository<Order> orderRepository, IRepository<Customer> custRepo, IRepository<Pizza> pizzarepo, int customerid)
        {

            GetOrdersResponse response = new GetOrdersResponse();

            var orders = await orderRepository.Get();
            var customerOrder = orders.Where(x => x.CustomerId == customerid);

            if (customerOrder != null)
            {
                foreach (Order ord in customerOrder)
                {
                    OrderDTO orderDTO = new OrderDTO();
                    Customer cust = await custRepo.GetById(customerid);
                    orderDTO.Customer = cust.Name;
                    Pizza pizza = await pizzarepo.GetById(ord.PizzaId);
                    orderDTO.Pizza = pizza.Name;
                    orderDTO.Total = pizza.Price;

                    if (ord.OrderStatus != Enums.OrderStatus.delivered)
                    {
                        TimeSpan timeSpent = DateTime.UtcNow - ord.TimeOfOrder;
                        if (timeSpent.Minutes <= 3)
                        {
                            ord.OrderStatus = Enums.OrderStatus.preparing;
                        }
                        if (timeSpent.Minutes > 3 && timeSpent.Minutes <= 12)
                        {
                            ord.OrderStatus = Enums.OrderStatus.cooking;
                        }
                        if (timeSpent.Minutes > 12)
                        {
                            ord.OrderStatus = Enums.OrderStatus.delivering;
                        }
                        orderDTO.OrderStatus = ord.OrderStatus.ToString();
                    }
                    orderDTO.OrderStatus = ord.OrderStatus.ToString();
                    response.Orders.Add(orderDTO);

                }
                await orderRepository.Save();

                return TypedResults.Ok(response);

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
            GetOrdersResponse response = new GetOrdersResponse();
            var orders = await orderRepo.Get();
            var customerOrder = orders.Where(x => x.CustomerId == id);

            if (customerOrder != null)
            {
                foreach (Order ord in customerOrder)
                {
                    OrderDTO orderDTO = new OrderDTO();
                    Customer customer = await custRepo.GetById(ord.CustomerId);
                    Pizza pizza = await pizzaRepo.GetById(ord.PizzaId);
                    orderDTO.Customer = customer.Name;
                    orderDTO.Pizza = pizza.Name;
                    orderDTO.Total = pizza.Price;

                    if (ord.OrderStatus == Enums.OrderStatus.delivered)
                    {
                        return TypedResults.BadRequest("Order is alredy delivered");
                    }
                    if (ord.OrderStatus != Enums.OrderStatus.delivering)
                    {
                        return TypedResults.BadRequest("Order is not ready");
                    }

                    ord.OrderStatus = Enums.OrderStatus.delivered;
                    await orderRepo.Update(ord);
                    orderDTO.OrderStatus = ord.OrderStatus.ToString();
                    response.Orders.Add(orderDTO);
                }

                await orderRepo.Save();
                return TypedResults.Ok(response);

            }
            return TypedResults.BadRequest("No order found");
        }

    }
}
