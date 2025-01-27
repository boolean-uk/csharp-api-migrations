using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Exceptions;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaGroup = app.MapGroup("pizzas");
            var orderGroup = app.MapGroup("orders");
            var customerGroup = app.MapGroup("customers");
            var deliveryGroup = app.MapGroup("deliveries");

            pizzaGroup.MapGet("/", GetPizzas);
            pizzaGroup.MapGet("/orders/{id}", GetPizzaByOrderId);
            pizzaGroup.MapPost("/", CreatePizza);

            orderGroup.MapGet("/", GetOrders);
            orderGroup.MapGet("/{id}", GetOrderById);
            orderGroup.MapGet("/{id}/pizzastatus", GetPizzaStatus);
            orderGroup.MapGet("/customers/{id}", GetOrdersByCustomerId);
            orderGroup.MapPost("/", CreateOrder);


            customerGroup.MapGet("/", GetCustomers);
            customerGroup.MapGet("/{id}", GetCustomerById);
            customerGroup.MapPost("/", CreateCustomer);

            deliveryGroup.MapGet("/", GetDrivers);
            deliveryGroup.MapGet("/{id}/orders", GetOrdersByDriverId);
            deliveryGroup.MapPut("/{id}/orders/{orderId}", AssignDriverToOrder);
            deliveryGroup.MapPut("/{id}/orders/{orderId}/delivered", DeliverOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repository, IMapper mapper)
        {
            try
            {
                var pizzas = await repository.GetAll();

                if (!pizzas.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<PizzaDTO>>(pizzas));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetCustomers(IRepository<Customer> repository, IMapper mapper)
        {
            try
            {
                var customers = await repository.GetAll();

                if (!customers.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<CustomerDTO>>(customers));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetOrders(IRepository<Order> repository, IMapper mapper)
        {
            try
            {
                var orders = await repository.GetAll(o => o.Pizza, o => o.Customer, o => o.DeliveryDriver);

                if (!orders.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<OrderDTO>>(orders));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetDrivers(IRepository<DeliveryDriver> repository, IMapper mapper)
        {
            try
            {
                var drivers = await repository.GetAll();

                if (!drivers.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<DeliveryDriverDTO>>(drivers));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPizzaByOrderId(IRepository<Order> repository, IMapper mapper, int id)
        {
            try
            {
                var order = await repository.Get(o => o.Id == id, o => o.Pizza);
                if (order == null) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<PizzaDTO>(order.Pizza));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetOrderById(IRepository<Order> repository, IMapper mapper, int id)
        {
            try
            {
                var order = await repository.Get(o => o.Id == id, o => o.Pizza, o => o.Customer, o => o.DeliveryDriver);
                if (order == null) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<OrderDTO>(order));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPizzaStatus(IRepository<Order> repository, IMapper mapper, int id)
        {
            try
            {
                var order = await repository.Get(o => o.PizzaId == id);
                if (order == null) return TypedResults.NotFound();

                return TypedResults.Ok(order.PizzaStatus.ToString());
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetOrdersByCustomerId(IRepository<Order> repository, IMapper mapper, int id)
        {
            try
            {
                var orders = await repository.FindAll(o => o.CustomerId == id, o => o.Pizza, o => o.Customer);
                if (!orders.Any()) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<IEnumerable<OrderDTO>>(orders));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetOrdersByDriverId(IRepository<DeliveryDriver> repository, IMapper mapper, int id)
        {
            try
            {
                var driver = await repository.GetWithCustomQuery(d => d.Id == id, query => query.Include(d => d.Orders).ThenInclude(o => o.Customer).Include(d => d.Orders).ThenInclude(o => o.Pizza));
                if (driver == null) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<DeliveryDriverWithOrdersDTO>(driver));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetCustomerById(IRepository<Customer> repository, IMapper mapper, int id)
        {
            try
            {
                var customer = await repository.Get(o => o.Id == id);
                if (customer == null) return TypedResults.NotFound();

                return TypedResults.Ok(mapper.Map<CustomerDTO>(customer));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreatePizza(IRepository<Pizza> repository, IMapper mapper, PizzaDTO model)
        {
            try
            {
                Pizza newPizza = new Pizza
                {
                    Name = model.Name,
                    Price = model.Price,
                };

                var pizza = await repository.Add(newPizza);

                return TypedResults.Created($"https://localhost:7235/pizzas/", mapper.Map<PizzaDTO>(pizza));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateCustomer(IRepository<Customer> repository, IMapper mapper, CustomerDTO model)
        {
            try
            {
                Customer newCustomer = new Customer
                {
                    Name = model.Name,
                };

                var customer = await repository.Add(newCustomer);

                return TypedResults.Created($"https://localhost:7235/customers/", mapper.Map<CustomerDTO>(customer));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateOrder(IRepository<Order> repository, IMapper mapper, CreateOrder model)
        {
            try
            {
                Order newOrder = new Order
                {
                    OrderTime = DateTime.UtcNow,
                    CustomerId = model.CustomerId,
                    PizzaId = model.PizzaId,
                    Status = OrderStatus.Incomplete,
                    PizzaStatus = PizzaStatus.Preparing
                };

                var order = await repository.Add(newOrder);

                return TypedResults.Created($"https://localhost:7235/orders/", mapper.Map<OrderDTO>(order));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> AssignDriverToOrder(IRepository<DeliveryDriver> repository, IRepository<Order> orderRepository, IMapper mapper, int driverId, int orderId)
        {
            try
            {
                var driver = await repository.Get(d => d.Id == driverId);
                var order = await orderRepository.Get(o => o.Id == orderId);

                if (driver == null || order == null) return TypedResults.NotFound();

                order.DeliveryDriverId = driver.Id;
                
                var updatedOrder = await orderRepository.Update(order);

                return TypedResults.Ok(mapper.Map<OrderDTO>(updatedOrder));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> DeliverOrder(IRepository<DeliveryDriver> repository, IRepository<Order> orderRepository, IMapper mapper, int driverId, int orderId)
        {
            try
            {
                var driver = await repository.Get(d => d.Id == driverId);
                var order = await orderRepository.Get(o => o.Id == orderId);

                if (driver == null || order == null) return TypedResults.NotFound();

                order.Status = OrderStatus.Complete;

                var updatedOrder = await orderRepository.Update(order);

                return TypedResults.Ok(mapper.Map<OrderDTO>(updatedOrder));
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "An unexpected error occurred while processing the request.",
                    Detail = ex.Message
                };

                return TypedResults.InternalServerError(errorResponse);
            }
        }

    }
}
