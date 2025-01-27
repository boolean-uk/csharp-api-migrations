using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaGroup = app.MapGroup("pizzaShop");

            pizzaGroup.MapGet("/pizzas", GetPizzas);
            pizzaGroup.MapGet("/pizzas/{id}", GetPizza);
            pizzaGroup.MapPost("/pizzas", AddPizza);
            pizzaGroup.MapGet("/customers", GetCustomers);
            pizzaGroup.MapGet("/customers/{id}", GetCustomer);
            pizzaGroup.MapPost("/customers", AddCustomer);
            pizzaGroup.MapGet("/orders", GetOrders);
            pizzaGroup.MapGet("/orders/{id}", GetOrder);
            pizzaGroup.MapGet("/ordersbycustomer/{id}", GetOrderByCustomer);
            pizzaGroup.MapGet("/ordersbydriver/{id}", GetOrderByDriver);
            pizzaGroup.MapPut("/orders/{id}", UpdateDriver);
            pizzaGroup.MapPost("/orders", AddOrder);
            pizzaGroup.MapGet("/toppings", GetToppings);
            pizzaGroup.MapGet("/toppings/{id}", GetTopping);
            pizzaGroup.MapPost("/toppings", AddTopping);
            pizzaGroup.MapGet("/ordertoppings", GetOrderToppings);
            pizzaGroup.MapGet("/ordertoppings/{id}", GetOrderTopping);
            pizzaGroup.MapGet("/ordertoppingsbyorder/{id}", GetOrderToppingByOrder);
            pizzaGroup.MapPost("/ordertoppings", AddOrderToppings);
        }

        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPizzas());
        }

        public static async Task<IResult> GetPizza(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetPizza(id));
        }

        public static async Task<IResult> AddPizza(IRepository repository, PizzaPost model)
        {
            Pizza pizza = new Pizza
            {
                Price = model.Price,
                Name = model.Name,
            };
            var result = await repository.AddPizza(pizza);
            return TypedResults.Created($"https://localhost:7138/pizzas/{result.Id}", result);
        }

        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetCustomers());
        }

        public static async Task<IResult> GetCustomer(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetCustomer(id));
        }

        public static async Task<IResult> AddCustomer(IRepository repository, CustomerPost model)
        {
            Customer customer = new Customer
            {
                Name = model.Name,
            };
            var result = await repository.AddCustomer(customer);
            return TypedResults.Created($"https://localhost:7138/customers/{result.Id}", result);
        }

        public static async Task<IResult> GetOrders(IRepository repository)
        {
            List<OrderDTO> orderDTOs = new List<OrderDTO>();
            var results = await repository.GetOrders();
            foreach (var order in results)
            {
                var customer = await repository.GetCustomer(order.CustomerId);
                var pizza = await repository.GetPizza(order.PizzaId);
                var driver = await repository.GetDriver(order.DriverId);
                if (driver == null)
                {
                    OrderDTO orderDTO = new OrderDTO
                    {
                        Id = order.Id,
                        CustomerId = customer.Id,
                        CustomerName = customer.Name,
                        PizzaId = pizza.Id,
                        PizzaName = pizza.Name,
                    };
                    orderDTOs.Add(orderDTO);
                }
                else 
                {
                    OrderDTO orderDTO = new OrderDTO
                    {
                        Id = order.Id,
                        CustomerId = customer.Id,
                        CustomerName = customer.Name,
                        PizzaId = pizza.Id,
                        PizzaName = pizza.Name,
                        DriverId = driver.Id,
                        DriverName = driver.Name,
                    };
                    orderDTOs.Add(orderDTO);
                }
                
            }
           
            return TypedResults.Ok(orderDTOs);
        }

        public static async Task<IResult> GetOrder(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetOrder(id));
        }

        public static async Task<IResult> GetOrderByCustomer(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetOrdersByCustomer(id));
        }

        public static async Task<IResult> GetOrderByDriver(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetOrdersByDriver(id));
        }

        public static async Task<IResult> UpdateDriver(IRepository repository,int id, OrderPut model)
        {
            var target = await repository.GetOrder(id);
            if (target == null) return TypedResults.NotFound("Order was not found");

            if (model.DriverId != null) target.DriverId = model.DriverId.Value;

            var result = await repository.UpdateOrder(target);

            return TypedResults.Created($"https://localhost:7138/orders/{result.Id}", result);


        }

        public static async Task<IResult> AddOrder(IRepository repository, OrderPost model)
        {
            Order order = new Order
            {
                CustomerId = model.CustomerId,
                PizzaId = model.PizzaId,
            };
            var result = await repository.AddOrder(order);
            return TypedResults.Created($"https://localhost:7138/orders/{result.Id}", result);
        }

        public static async Task<IResult> GetToppings(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetToppings());
        }

        public static async Task<IResult> GetTopping(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetTopping(id));
        }

        public static async Task<IResult> AddTopping(IRepository repository, ToppingPost model)
        {
            Topping topping = new Topping
            {
                Name = model.Name,
                Price = model.Price,
            };
            var result = await repository.AddTopping(topping);
            return TypedResults.Created($"https://localhost:7138/toppings/{result.Id}", result);

        }

        public static async Task<IResult> GetOrderToppings(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetOrderToppings());
        }

        public static async Task<IResult> GetOrderTopping(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetOrderTopping(id));
        }

        public static async Task<IResult> GetOrderToppingByOrder(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetOrderToppingsByOrder(id));
        }

        public static async Task<IResult> AddOrderToppings(IRepository repository, OrderToppingsPost model)
        {
            OrderToppings orderToppings = new OrderToppings
            {
                OrderId = model.OrderId,
                ToppingId = model.ToppingId,
            };
            var result = await repository.AddOrderToppings(orderToppings);
            return TypedResults.Created($"https://localhost:7138/ordertoppings/{result.Id}", result);

        }

    }
}
