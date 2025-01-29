using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var shop = app.MapGroup("shop");

            shop.MapGet("/orders", GetAllOrders);
            shop.MapGet("/orders/{id}", GetOrderById);
            shop.MapPost("/orders", CreateOrder);
            shop.MapGet("/orders/{id}/status", GetOrderStatusById);
            shop.MapPost("/orders/{id}/status", UpdateOrderStatus);
            shop.MapPost("/orders/{id}/toppings", AddToppingsToOrder);

            shop.MapGet("/customers", GetAllCustomers);
            shop.MapGet("/customer/{id}", GetCustomerById);
            shop.MapPost("/customers", CreateCustomer);

            shop.MapGet("/pizzas", GetAllPizzas);
            shop.MapGet("/pizzas/{id}", GetPizzaById);
            shop.MapPost("/pizzas", CreatePizza);

            shop.MapGet("/toppings", GetAllToppings);
            shop.MapGet("/toppings/{id}", GetToppingById);
            shop.MapPost("/toppings", CreateTopping);
        }

        private static string baseUrl(HttpContext context) {
            return $"{context.Request.Scheme}://{context.Request.Host}";
        }

        private static async Task<IResult> CreateTopping(HttpContext context, [FromServices] IRepository<Topping> repository, [FromServices] IMapper mapper, ToppingPost toppingPost)
        {
            try
            {
                Topping topping = mapper.Map<Topping>(toppingPost);
                topping = await repository.Create(topping);

                var response = mapper.Map<ToppingDTO>(topping);
                return TypedResults.Created($"{baseUrl(context)}/shop/toppings/{topping.Id}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetToppingById(HttpContext context, [FromServices] IRepository<Topping> repository, [FromServices] IMapper mapper, int id)
        {
            try
            {
                var topping = await repository.GetById(id);
                if (topping == null)
                {
                    return TypedResults.NotFound();
                }

                var response = mapper.Map<ToppingDTO>(topping);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetAllToppings(HttpContext context, [FromServices] IRepository<Topping> repository, [FromServices] IMapper mapper)
        {
            var results = await repository.GetAll();
            var response = mapper.Map<IEnumerable<ToppingDTO>>(results);

            return TypedResults.Ok(response);
        }

        private static async Task<IResult> CreatePizza(HttpContext context, [FromServices] IRepository<Pizza> repository, [FromServices] IMapper mapper, PizzaPost pizzaPost)
        {
            try
            {
                Pizza pizza = mapper.Map<Pizza>(pizzaPost);
                pizza = await repository.Create(pizza);

                var response = mapper.Map<PizzaDTO>(pizza);
                return TypedResults.Created($"{baseUrl(context)}/shop/pizzas/{pizza.Id}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetPizzaById(HttpContext context, [FromServices] IRepository<Pizza> repository, [FromServices] IMapper mapper, int id)
        {
            try
            {
                var pizza = await repository.GetById(id);
                if (pizza == null)
                {
                    return TypedResults.NotFound();
                }

                var response = mapper.Map<PizzaDTO>(pizza);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetAllPizzas(HttpContext context, [FromServices] IRepository<Pizza> repository, [FromServices] IMapper mapper)
        {
            var results = await repository.GetAll();
            var response = mapper.Map<IEnumerable<PizzaDTO>>(results);

            return TypedResults.Ok(response);
        }

        private static async Task<IResult> CreateCustomer(HttpContext context, [FromServices] IRepository<Customer> repository, [FromServices] IMapper mapper, CustomerPost customerPost)
        {
            try
            {
                Customer customer = mapper.Map<Customer>(customerPost);
                customer = await repository.Create(customer);

                var response = mapper.Map<CustomerDTO>(customer);
                return TypedResults.Created($"{baseUrl(context)}/shop/customers/{customer.Id}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetCustomerById(HttpContext context, [FromServices] IRepository<Customer> repository, [FromServices] IMapper mapper, int id)
        {
            try
            {
                var customer = await repository.GetById(id);
                if (customer == null)
                {
                    return TypedResults.NotFound();
                }

                var response = mapper.Map<CustomerDTO>(customer);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetAllCustomers(HttpContext context, [FromServices] IRepository<Customer> repository, [FromServices] IMapper mapper)
        {
            var results = await repository.GetAll();
            var response = mapper.Map<IEnumerable<CustomerDTO>>(results);

            return TypedResults.Ok(response);
        }

        private static async Task<IResult> CreateOrder(HttpContext context, [FromServices] IRepository<Order> repository, [FromServices] IMapper mapper, OrderPost orderPost)
        {
            try
            {
                Order order = mapper.Map<Order>(orderPost);
                order = await repository.Create(order);

                var response = mapper.Map<OrderDTO>(order);
                return TypedResults.Created($"{baseUrl(context)}/shop/orders/{order.Id}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetOrderById(HttpContext context, [FromServices] IRepository<Order> repository, [FromServices] IMapper mapper, int id)
        {
            try
            {
                var order = await repository.GetById(id);
                if (order == null)
                {
                    return TypedResults.NotFound();
                }

                var response = mapper.Map<OrderDTO>(order);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetAllOrders(HttpContext context, [FromServices] IRepository<Order> repository, [FromServices] IMapper mapper)
        {
            var results = await repository.GetWithIncludes(o => o.Customer, o => o.Pizza);
            var response = mapper.Map<IEnumerable<OrderDTO>>(results);

            return TypedResults.Ok(response);
        }

        private static async Task<IResult> GetOrderStatusById(HttpContext context, [FromServices] IRepository<Order> repository, [FromServices] IMapper mapper, int id)
        {
            try
            {
                var order = await repository.GetById(id);
                if (order == null)
                {
                    return TypedResults.NotFound();
                }

                var response = mapper.Map<OrderStatusDTO>(order);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> AddToppingsToOrder(HttpContext context, [FromServices] IRepository<OrderToppings> repository, [FromServices] IRepository<Order> orderRepo, [FromServices] IRepository<Topping> toppingRepo, [FromServices] IMapper mapper, ToppingOrderPost toppingPost)
        {
            try
            {
                var order = await orderRepo.GetById(toppingPost.OrderId);
                if (order == null)
                {
                    return TypedResults.NotFound("Order not found");
                }

                var topping = await toppingRepo.GetById(toppingPost.ToppingId);
                if (topping == null)
                {
                    return TypedResults.NotFound("Topping not found");
                }

                OrderToppings orderTopping = new()
                {
                    OrderId = toppingPost.OrderId,
                    ToppingId = toppingPost.ToppingId,
                    Order = order,
                    Topping = topping
                };

                await repository.Create(orderTopping);

                var response = mapper.Map<OrderDTO>(order);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return TypedResults.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateOrderStatus(HttpContext context, [FromServices] IRepository<Order> repository, [FromServices] IMapper mapper, OrderStatusPut orderStatusPut)
        {
            try
            {
                Order order = mapper.Map<Order>(orderStatusPut);
                order = await repository.Update(order);

                var response = mapper.Map<OrderStatusDTO>(order);
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
