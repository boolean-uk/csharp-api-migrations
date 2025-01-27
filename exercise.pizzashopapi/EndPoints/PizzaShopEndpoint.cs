using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopEndpoint
    {
        public static void ConfigurePizzaShopEndpoint(this WebApplication app)
        {
            var customerGroup = app.MapGroup("customer");
            var orderGroup = app.MapGroup("order");
            var pizzaGroup = app.MapGroup("pizza");
            var toppingGroup = app.MapGroup("topping");

            customerGroup.MapPost("/", CreateCustomer);
            customerGroup.MapGet("/", GetCustomers);
            customerGroup.MapGet("/{id}", GetCustomerById);
            customerGroup.MapPut("/{id}", UpdateCustomer);
            customerGroup.MapDelete("/{id}", DeleteCustomer);

            orderGroup.MapPost("/", CreateOrder);
            orderGroup.MapGet("/", GetOrders);
            orderGroup.MapGet("/{id}", GetOrderById);
            orderGroup.MapPut("/{id}", UpdateOrder);
            orderGroup.MapDelete("/{id}", DeleteOrder);
            orderGroup.MapPost("/{orderId}/topping/{toppingId}", AddToppingToOrder);
            orderGroup.MapPut("/{id}/delivered", SetOrderAsDelivered);
            orderGroup.MapGet("/{id}/status", GetOrderStatus);

            pizzaGroup.MapPost("/", CreatePizza);
            pizzaGroup.MapGet("/", GetPizzas);
            pizzaGroup.MapGet("/{id}", GetPizzaById);
            pizzaGroup.MapPut("/{id}", UpdatePizza);
            pizzaGroup.MapDelete("/{id}", DeletePizza);
            pizzaGroup.MapPost("/{pizzaId}/topping/{toppingId}", AddToppingToPizza);

            toppingGroup.MapPost("/", CreateTopping);
            toppingGroup.MapGet("/", GetToppings);
            toppingGroup.MapGet("/{id}", GetToppingById);
            toppingGroup.MapPut("/{id}", UpdateTopping);
            toppingGroup.MapDelete("/{id}", DeleteTopping);
        }

        #region customer

        public static async Task<IResult> CreateCustomer(IRepository<Customer> customerRepository, string name)
        {
            var customer = new Customer { Name = name };
            var createdCustomer = await customerRepository.Insert(customer);
            return TypedResults.Created($"/customer/{createdCustomer.Id}", createdCustomer);
        }

        public static async Task<IResult> GetCustomers(IRepository<Customer> customerRepository)
        {
            var customers = await customerRepository.Get();
            return TypedResults.Ok(customers);
        }

        public static async Task<IResult> GetCustomerById(IRepository<Customer> customerRepository, int id)
        {
            var customer = await customerRepository.GetById(id);
            if (customer == null)
            {
                return TypedResults.NotFound(new { Message = "Customer not found" });
            }
            return TypedResults.Ok(customer);
        }

        public static async Task<IResult> UpdateCustomer(IRepository<Customer> customerRepository, int id, string? name)
        {
            var customer = await customerRepository.GetById(id);
            if (customer == null)
            {
                return TypedResults.NotFound(new { Message = "Customer not found" });
            }
            if (name != null && name != customer.Name)
            {
                customer.Name = name;
            }
            var updatedCustomer = await customerRepository.Update(customer);
            return TypedResults.Ok(updatedCustomer);
        }

        public static async Task<IResult> DeleteCustomer(IRepository<Customer> customerRepository, int id)
        {
            var customer = await customerRepository.GetById(id);
            if (customer == null)
            {
                return TypedResults.NotFound(new { Message = "Customer not found" });
            }
            var deletedCustomer = await customerRepository.Delete(id);
            return TypedResults.Ok(deletedCustomer);
        }

        #endregion

        #region order

        public static async Task<IResult> CreateOrder(
            IRepository<Order> orderRepository,
            IRepository<Customer> customerRepository,
            IRepository<Pizza> pizzaRepository,
            int customerId,
            int pizzaId)
        {
            var customer = await customerRepository.GetById(customerId);
            if (customer == null)
            {
                return TypedResults.NotFound(new { Message = "Customer not found" });
            }

            var pizza = await pizzaRepository.GetById(pizzaId);
            if (pizza == null)
            {
                return TypedResults.NotFound(new { Message = "Pizza not found" });
            }

            var order = new Order
            {
                CustomerId = customerId,
                PizzaId = pizzaId,
                Status = "Preparing",
                CreatedAt = DateTime.UtcNow
            };

            var createdOrder = await orderRepository.Insert(order);

            return TypedResults.Created($"/order/{createdOrder.Id}", createdOrder);
        }


        public static async Task<IResult> GetOrders(IRepository<Order> orderRepository)
        {
            var orders = await orderRepository.GetWithIncludes(
                o => o.customer,          
                o => o.pizza,             
                o => o.pizza.Toppings,    
                o => o.OrderToppings      
            );

            var orderDetails = orders.Select(order => new
            {
                order.Id,
                order.CustomerId,
                Customer = order.customer,
                order.PizzaId,
                Pizza = order.pizza,
                Toppings = order.pizza?.Toppings,
                OrderToppings = order.OrderToppings,
                order.Status,
                order.CreatedAt,
                order.CookingStartedAt,
                order.DeliveredAt
            }).ToList();

            return TypedResults.Ok(orderDetails);
        }


        public static async Task<IResult> GetOrderById(IRepository<Order> orderRepository, int id)
        {
            var orders = await orderRepository.GetWithIncludes(
                o => o.customer,
                o => o.pizza,
                o => o.pizza.Toppings,
                o => o.OrderToppings
                
            );

            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return TypedResults.NotFound(new { Message = "Order not found" });
            }
            return TypedResults.Ok(order);
        }

        public static async Task<IResult> UpdateOrder(
            IRepository<Order> orderRepository,
            IRepository<Customer> customerRepository,
            IRepository<Pizza> pizzaRepository,
            int id,
            int? customerId,
            int? pizzaId)
        {
            var orders = await orderRepository.GetWithIncludes(
                o => o.customer,
                o => o.pizza,
                o => o.pizza.Toppings,
                o => o.OrderToppings
            );

            var order = orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return TypedResults.NotFound(new { Message = "Order not found" });
            }

            if (customerId != null)
            {
                var customer = await customerRepository.GetById((int)customerId);
                if (customer == null)
                {
                    return TypedResults.NotFound(new { Message = "Customer not found" });
                }
                order.CustomerId = (int)customerId;
            }

            if (pizzaId != null)
            {
                var pizza = await pizzaRepository.GetById((int)pizzaId);
                if (pizza == null)
                {
                    return TypedResults.NotFound(new { Message = "Pizza not found" });
                }
                order.PizzaId = (int)pizzaId;
            }

            var updatedOrder = await orderRepository.Update(order);
            return TypedResults.Ok(updatedOrder);
        }

        public static async Task<IResult> DeleteOrder(IRepository<Order> orderRepository, int id)
        {
            var orders = await orderRepository.GetWithIncludes(
                o => o.customer,
                o => o.pizza,
                o => o.pizza.Toppings,
                o => o.OrderToppings
            );

            var order = orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return TypedResults.NotFound(new { Message = "Order not found" });
            }

            var deletedOrder = await orderRepository.Delete(id);

            return TypedResults.Ok(deletedOrder);
        }

        public static async Task<IResult> SetOrderAsDelivered(
            IRepository<Order> orderRepository,
            int orderId)
        {
            var order = await orderRepository.GetById(orderId);
            if (order == null)
            {
                return TypedResults.NotFound(new { Message = "Order not found" });
            }

            order.Status = "Delivered";
            order.DeliveredAt = DateTime.UtcNow;

            var updatedOrder = await orderRepository.Update(order);

            return TypedResults.Ok(updatedOrder);
        }

        public static async Task<IResult> GetOrderStatus(
            IRepository<Order> orderRepository,
            int orderId)
        {
            var order = await orderRepository.GetById(orderId);
            if (order == null)
            {
                return TypedResults.NotFound(new { Message = "Order not found" });
            }

            return TypedResults.Ok(new { order.Id, order.Status });
        }

        #endregion

        #region pizza

        public static async Task<IResult> CreatePizza(IRepository<Pizza> pizzaRepository, string name, decimal price)
        {
            var pizza = new Pizza { Name = name, Price = price };
            var createdPizza = await pizzaRepository.Insert(pizza);
            return TypedResults.Created($"/pizza/{createdPizza.Id}", createdPizza);
        }

        public static async Task<IResult> GetPizzas(IRepository<Pizza> pizzaRepository)
        {
            var pizzas = await pizzaRepository.Get();
            return TypedResults.Ok(pizzas);
        }

        public static async Task<IResult> GetPizzaById(IRepository<Pizza> pizzaRepository, int id)
        {
            var pizza = await pizzaRepository.GetById(id);
            if (pizza == null)
            {
                return TypedResults.NotFound(new { Message = "Pizza not found" });
            }
            return TypedResults.Ok(pizza);
        }

        public static async Task<IResult> UpdatePizza(IRepository<Pizza> pizzaRepository, int id, string? name, decimal? price)
        {
            var pizza = await pizzaRepository.GetById(id);
            if (pizza == null)
            {
                return TypedResults.NotFound(new { Message = "Pizza not found" });
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                pizza.Name = name;
            }
            if (price >= 0 && price != null)
            {
                pizza.Price = (decimal) price;
            }

            var updatedPizza = await pizzaRepository.Update(pizza);
            return TypedResults.Ok(updatedPizza);
        }

        public static async Task<IResult> DeletePizza(IRepository<Pizza> pizzaRepository, int id)
        {
            var pizza = await pizzaRepository.GetById(id);
            if (pizza == null)
            {
                return TypedResults.NotFound(new { Message = "Pizza not found" });
            }
            var deletedPizza = await pizzaRepository.Delete(id);
            return TypedResults.Ok(deletedPizza);
        }

        #endregion

        #region topping

        public static async Task<IResult> CreateTopping(IRepository<Topping> toppingRepository, string name, decimal price)
        {
            var topping = new Topping { Name = name, Price = price };
            var createdTopping = await toppingRepository.Insert(topping);
            return TypedResults.Created($"/topping/{createdTopping.Id}", createdTopping);
        }

        public static async Task<IResult> GetToppings(IRepository<Topping> toppingRepository)
        {
            var toppings = await toppingRepository.Get();
            return TypedResults.Ok(toppings);
        }

        public static async Task<IResult> GetToppingById(IRepository<Topping> toppingRepository, int id)
        {
            var topping = await toppingRepository.GetById(id);
            if (topping == null)
            {
                return TypedResults.NotFound(new { Message = "Topping not found" });
            }
            return TypedResults.Ok(topping);
        }

        public static async Task<IResult> UpdateTopping(IRepository<Topping> toppingRepository, int id, string? name, decimal? price)
        {
            var topping = await toppingRepository.GetById(id);
            if (topping == null)
            {
                return TypedResults.NotFound(new { Message = "Topping not found" });
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                topping.Name = name;
            }
            if (price >= 0 && price != null)
            {
                topping.Price = (decimal)price;
            }

            var updatedTopping = await toppingRepository.Update(topping);
            return TypedResults.Ok(updatedTopping);
        }

        public static async Task<IResult> DeleteTopping(IRepository<Topping> toppingRepository, int id)
        {
            var topping = await toppingRepository.GetById(id);
            if (topping == null)
            {
                return TypedResults.NotFound(new { Message = "Topping not found" });
            }
            var deletedTopping = await toppingRepository.Delete(id);
            return TypedResults.Ok(deletedTopping);
        }

        public static async Task<IResult> AddToppingToPizza(
            IRepository<Pizza> pizzaRepository,
            IRepository<Topping> toppingRepository,
            int pizzaId,
            int toppingId)
        {
            var pizza = await pizzaRepository.GetWithIncludes(p => p.Toppings);
            var selectedPizza = pizza.FirstOrDefault(p => p.Id == pizzaId);

            if (selectedPizza == null)
                return TypedResults.NotFound(new { Message = "Pizza not found" });

            var topping = await toppingRepository.GetById(toppingId);

            if (topping == null)
                return TypedResults.NotFound(new { Message = "Topping not found" });

            selectedPizza.Toppings ??= new List<Topping>();
            selectedPizza.Toppings.Add(topping);

            await pizzaRepository.Update(selectedPizza);
            return TypedResults.Ok(selectedPizza);
        }

        public static async Task<IResult> AddToppingToOrder(
            IRepository<OrderTopping> orderToppingRepository,
            IRepository<Order> orderRepository,
            IRepository<Topping> toppingRepository,
            int orderId,
            int toppingId)
        {
            var order = await orderRepository.GetById(orderId);
            if (order == null)
                return TypedResults.NotFound(new { Message = "Order not found" });

            var topping = await toppingRepository.GetById(toppingId);
            if (topping == null)
                return TypedResults.NotFound(new { Message = "Topping not found" });

            var orderTopping = new OrderTopping { OrderId = orderId, ToppingId = toppingId };
            var createdOrderTopping = await orderToppingRepository.Insert(orderTopping);
            return TypedResults.Ok(createdOrderTopping);
        }

        #endregion

    }
}
