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

            pizzaGroup.MapPost("/", CreatePizza);
            pizzaGroup.MapGet("/", GetPizzas);
            pizzaGroup.MapGet("/{id}", GetPizzaById);
            pizzaGroup.MapPut("/{id}", UpdatePizza);
            pizzaGroup.MapDelete("/{id}", DeletePizza);
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

        public static async Task<IResult> CreateOrder(IRepository<Order> orderRepository, IRepository<Customer> customerRepository, IRepository<Pizza> pizzaRepository, int customerId, int pizzaId)
        {
            // Check if the customer exists
            var customer = await customerRepository.GetById(customerId);
            if (customer == null)
            {
                return TypedResults.NotFound(new { Message = "Customer not found" });
            }

            // Check if the pizza exists
            var pizza = await pizzaRepository.GetById(pizzaId);
            if (pizza == null)
            {
                return TypedResults.NotFound(new { Message = "Pizza not found" });
            }

            // Create the order
            var order = new Order { CustomerId = customerId, PizzaId = pizzaId };
            var createdOrder = await orderRepository.Insert(order);
            return TypedResults.Created($"/order/{createdOrder.Id}", createdOrder);
        }


        public static async Task<IResult> GetOrders(IRepository<Order> orderRepository)
        {
            var orders = await orderRepository.GetWithIncludes(
                o => o.customer,
                o => o.pizza
            );
            return TypedResults.Ok(orders);
        }

        public static async Task<IResult> GetOrderById(IRepository<Order> orderRepository, int id)
        {
            var orders = await orderRepository.GetWithIncludes(
                o => o.customer,
                o => o.pizza
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
            var orders = await orderRepository.GetWithIncludes(o => o.customer, o => o.pizza);
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
            var orders = await orderRepository.GetWithIncludes(o => o.customer, o => o.pizza);
            var order = orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return TypedResults.NotFound(new { Message = "Order not found" });
            }

            var deletedOrder = await orderRepository.Delete(id);

            return TypedResults.Ok(deletedOrder);
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
    }
}
