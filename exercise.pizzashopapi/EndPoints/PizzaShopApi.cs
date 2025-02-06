using System.Configuration;
using AutoMapper;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaShop = app.MapGroup("pizzashop");


            pizzaShop.MapGet("/pizza", GetPizzas);
            pizzaShop.MapGet("/pizza/{id}", GetPizzaById);
            pizzaShop.MapPost("/pizza", CreatePizza);
            pizzaShop.MapPut("/pizza/{id}", UpdatePizza);
            pizzaShop.MapDelete("/pizza/{id}", DeletePizza);

            pizzaShop.MapGet("/customers", GetCustomers);
            pizzaShop.MapGet("/customers/{id}", GetCustomerById);
            pizzaShop.MapPost("/customers", CreateCustomer);
            pizzaShop.MapPut("/customers/{id}", UpdateCustomer);
            pizzaShop.MapDelete("/customers/{id}", DeleteCustomer);

            pizzaShop.MapGet("/orders", GetOrders);
            pizzaShop.MapGet("/orders/{id}", GetOrderById);
            pizzaShop.MapGet("/ordersbycustomer/{id}", GetOrderByCustomer);
            pizzaShop.MapPost("/orders", CreateOrder);
            pizzaShop.MapPut("/orders/{id}", UpdateOrder);
            pizzaShop.MapDelete("/orders/{id}", DeleteOrder);
        }

        // Pizza
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> pizzaRepo, IMapper mapper)
        {
            var pizzas = await pizzaRepo.Get();

            var result = pizzas.Select(p => new PizzaDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzaById(IRepository<Pizza> pizzaRepo, int id, IMapper mapper)
        {
            var pizzas = await pizzaRepo.Get();
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza == null) return TypedResults.NotFound($"No pizza found for id {id}");

            var result =  new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price
            };
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePizza(IRepository<Pizza> pizzaRepo, PizzaPost model, IMapper mapper)
        {
            if (string.IsNullOrWhiteSpace(model.Name) ||
                model.Price == null ) return Results.BadRequest("Pizza's input was formatted wrong.");

            var pizza = new Pizza()
            {
                Name = model.Name,
                Price = model.Price
            };

            pizza = await pizzaRepo.Insert(pizza);

            var result = new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price
            };
            return Results.Created($"/pizzas/{pizza.Id}", result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdatePizza(IRepository<Pizza> pizzaRepo, int id, PizzaPut model, IMapper mapper)
        {
            if (string.IsNullOrWhiteSpace(model.Name) ||
                model.Price == null) return Results.BadRequest("Pizza's input was formatted wrong.");

            var pizza = await pizzaRepo.GetById(id);
            if (pizza == null) return Results.NotFound("Pizza not found");
            if (model.Name != null) pizza.Name = model.Name;
            if (model.Price != null) pizza.Price = (decimal)model.Price;

            pizza = await pizzaRepo.Update(pizza);

            var result = new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price
            };

            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeletePizza(IRepository<Pizza> pizzaRepo, int id, IMapper mapper)
        {
            var pizza = await pizzaRepo.GetById(id);
            if (pizza == null) return Results.NotFound("Pizza not found");

            pizza = await pizzaRepo.Delete(pizza);

            var result = new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price
            };

            return Results.Ok(result);
        }





        // Customer
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository<Customer> customerRepo, IRepository<Order> orderRepo, IMapper mapper)
        {
            var customers = await customerRepo.GetWithIncludes(c => c.Orders);

            var result = customers.Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Orders = c.Orders.Select(o => new OrderCustomerDTO
                {
                    PizzaName = o.Pizza.Name,
                    PizzaPrice = o.Pizza.Price
                }).ToList()
            }).ToList();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomerById(IRepository<Customer> customerRepo, IRepository<Order> orderRepo, int id, IMapper mapper)
        {
            var customers = await customerRepo.GetWithIncludes(c => c.Orders);
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer == null) return TypedResults.NotFound($"No customer found for id {id}");

            var result = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Orders = customer.Orders.Select(o => new OrderCustomerDTO
                {
                    PizzaName = o.Pizza.Name,
                    PizzaPrice = o.Pizza.Price
                }).ToList()
            };
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCustomer(IRepository<Customer> customerRepo, CustomerPost model, IMapper mapper)
        {
            if (string.IsNullOrWhiteSpace(model.Name)) return Results.BadRequest("Customer's input was formatted wrong.");

            var customer = new Customer()
            {
                Name = model.Name
            };

            customer = await customerRepo.Insert(customer);

            var result = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Orders = customer.Orders.Select(o => new OrderCustomerDTO
                {
                    PizzaName = o.Pizza.Name,
                    PizzaPrice = o.Pizza.Price
                }).ToList()
            };
            return Results.Created($"/customers/{customer.Id}", result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateCustomer(IRepository<Customer> customerRepo, int id, CustomerPut model, IMapper mapper)
        {
            if (string.IsNullOrWhiteSpace(model.Name)) return Results.BadRequest("Customer's input was formatted wrong.");

            var customer = await customerRepo.GetById(id);
            if (customer == null) return Results.NotFound("Customer not found");
            if (model.Name != null) customer.Name = model.Name;

            customer = await customerRepo.Update(customer);

            var result = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Orders = customer.Orders.Select(o => new OrderCustomerDTO
                {
                    PizzaName = o.Pizza.Name,
                    PizzaPrice = o.Pizza.Price
                }).ToList()
            };
            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCustomer(IRepository<Customer> customerRepo, int id, IMapper mapper)
        {
            var customer = await customerRepo.GetById(id);
            if (customer == null) return Results.NotFound("Customer not found");

            customer = await customerRepo.Delete(customer);

            var result = new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Orders = customer.Orders.Select(o => new OrderCustomerDTO
                {
                    PizzaName = o.Pizza.Name,
                    PizzaPrice = o.Pizza.Price
                }).ToList()
            };

            return Results.Ok(result);
        }





        // Customer
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> orderRepo, IMapper mapper)
        {
            var orders = await orderRepo.GetWithIncludes(o => o.Pizza, o => o.Customer);

            var result = orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                CustomerName = o.Customer.Name,
                PizzaName = o.Pizza.Name,
                PizzaPrice = o.Pizza.Price
            }).ToList();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrderById(IRepository<Order> orderRepo, int id, IMapper mapper)
        {
            var orders = await orderRepo.GetWithIncludes(o => o.Pizza, o => o.Customer);
            var order = orders.FirstOrDefault(c => c.Id == id);

            if (order == null) return TypedResults.NotFound($"No order found for id {id}");

            var result = new OrderDTO
            {
                Id = order.Id,
                CustomerName = order.Customer.Name,
                PizzaName = order.Pizza.Name,
                PizzaPrice = order.Pizza.Price
            };
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrderByCustomer(IRepository<Order> orderRepo, int id, IMapper mapper)
        {
            var orders = await orderRepo.GetWithIncludes(o => o.Pizza, o => o.Customer);

            var result = orders.Where(o => o.CustomerId == id).Select(o => new OrderDTO
            {
                Id = o.Id,
                CustomerName = o.Customer.Name,
                PizzaName = o.Pizza.Name,
                PizzaPrice = o.Pizza.Price
            }).ToList();
            if (!result.Any()) return TypedResults.NotFound($"No orders found for customer id {id}");
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateOrder(IRepository<Order> orderRepo, OrderPost model, IMapper mapper)
        {
            if (model.CustomerId == null ||
                model.PizzaId == null) return Results.BadRequest("Order's input was formatted wrong.");

            var order = new Order()
            {
                CustomerId = model.CustomerId,
                PizzaId = model.PizzaId                
            };

            order = await orderRepo.Insert(order);

            var result = new OrderDTO
            {
                Id = order.Id,
                CustomerName = order.Customer.Name,
                PizzaName = order.Pizza.Name,
                PizzaPrice = order.Pizza.Price
            };
            return Results.Created($"/orders/{order.Id}", result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateOrder(IRepository<Order> orderRepo, int id, OrderPut model, IMapper mapper)
        {
            if (model.CustomerId == null ||
                model.PizzaId == null) return Results.BadRequest("Order's input was formatted wrong.");

            var orders = await orderRepo.GetWithIncludes(o => o.Pizza, o => o.Customer);
            var order = orders.FirstOrDefault(c => c.Id == id);

            if (order == null) return TypedResults.NotFound($"No order found for id {id}");

            if (model.CustomerId != null) order.CustomerId = (int)model.CustomerId;
            if (model.PizzaId != null) order.PizzaId = (int)model.PizzaId;

            order = await orderRepo.Update(order);

            var result = new OrderDTO
            {
                Id = order.Id,
                CustomerName = order.Customer.Name,
                PizzaName = order.Pizza.Name,
                PizzaPrice = order.Pizza.Price
            };
            return Results.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteOrder(IRepository<Order> orderRepo, int id, IMapper mapper)
        {
            var orders = await orderRepo.GetWithIncludes(o => o.Pizza, o => o.Customer);
            var order = orders.FirstOrDefault(c => c.Id == id);

            if (order == null) return TypedResults.NotFound($"No order found for id {id}");

            order = await orderRepo.Delete(order);

            var result = new OrderDTO
            {
                Id = order.Id,
                CustomerName = order.Customer.Name,
                PizzaName = order.Pizza.Name,
                PizzaPrice = order.Pizza.Price
            };

            return Results.Ok(result);
        }











    }
}
