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
            pizzaShopGroup.MapGet("/customers", GetCustomers);
            pizzaShopGroup.MapGet("/customers/{id}", GetCustomerById);
            pizzaShopGroup.MapPost("/customers", CreateCustomer);
            pizzaShopGroup.MapDelete("/customers", DeleteCustomer);

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
        public static async Task<IResult> GetOrdersByCustomer(IRepository repository, int id)
        {
            var results = await repository.GetOrdersByCustomer(id);
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrderById(IRepository repository, int customerId, int pizzaId)
        {
            try
            {
                var result = await repository.GetOrderById(customerId, pizzaId);
                if (result is null)
                {
                    return TypedResults.NotFound("Order Not Found");
                }

                ResponseOrderDTO responseOrder = CreateResponseOrderDTO(result);

                return TypedResults.Ok(responseOrder);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.ToString());
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateOrder(IRepository repository, PostOrderDTO model)
        {
            try
            {
                if (model == null)
                {
                    return TypedResults.BadRequest($"Invalid order object");
                }

                var targetCustomer = await repository.GetCustomerById(model.CustomerId);
                if (targetCustomer is null)
                {
                    return TypedResults.BadRequest($"Customer not found");
                }

                var targetPizza = await repository.GetPizzaById(model.PizzaId);
                if (targetPizza is null)
                {
                    return TypedResults.BadRequest($"Pizza not found");
                }

                var newOrder = await repository.CreateOrder(new Order { CreatedAt = DateTime.UtcNow, Delivered = false, CustomerId = model.CustomerId, PizzaId = model.PizzaId });
                ResponseOrderDTO responseOrder = CreateResponseOrderDTO(newOrder);

                return TypedResults.Created($"https://localhost:7054/orders/{responseOrder.CustomerId}&{responseOrder.PizzaId}", responseOrder);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest($"Invalid order object - {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteOrder(IRepository repository, int customerId, int pizzaId)
        {
            try
            {
                var target = await repository.DeleteOrder(customerId, pizzaId);
                if (target is null)
                {
                    return TypedResults.NotFound("Order Not Found");
                }

                //custom DTO
                ResponseOrderDTO responseOrder = CreateResponseOrderDTO(target);

                return TypedResults.Ok(responseOrder);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
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



        // ------ Pizzas ------
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            var results = await repository.GetPizzas();
            List<Pizza> pizzas = results.ToList();
            if (pizzas.Count <= 0)
            {
                return TypedResults.NoContent();
            }

            List<ResponsePizzaDTO> responsePizzas = new List<ResponsePizzaDTO>();

            foreach (Pizza p in pizzas)
            {
                responsePizzas.Add(CreateResponsePizzaDTO(p));
            }

            return TypedResults.Ok(responsePizzas);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizzaById(IRepository repository, int id)
        {
            try
            {
                var result = await repository.GetPizzaById(id);
                if (result is null)
                {
                    return TypedResults.NotFound("Pizza Not Found");
                }

                ResponsePizzaDTO responsePizza = CreateResponsePizzaDTO(result);

                return TypedResults.Ok(responsePizza);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.ToString());
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreatePizza(IRepository repository, PostPizzaDTO model)
        {
            try
            {
                if (model == null)
                {
                    return TypedResults.BadRequest($"Invalid pizza object");
                }

                if (String.IsNullOrEmpty(model.Name))
                {
                    return TypedResults.BadRequest($"Pizza name is invalid or empty");
                }

                var newPizza = await repository.CreatePizza(new Pizza { CreatedAt = DateTime.UtcNow, Name = model.Name, Price = model.Price });
                ResponsePizzaDTO responsePizza = CreateResponsePizzaDTO(newPizza);

                return TypedResults.Created($"https://localhost:7054/pizzas/{responsePizza.Id}", responsePizza);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest($"Invalid pizza object - {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeletePizza(IRepository repository, int id)
        {
            try
            {
                var target = await repository.DeletePizza(id);
                if (target is null)
                {
                    return TypedResults.NotFound("Pizza Not Found");
                }

                //custom DTO
                ResponsePizzaDTO responsePizza = CreateResponsePizzaDTO(target);

                return TypedResults.Ok(responsePizza);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        public static ResponsePizzaDTO CreateResponsePizzaDTO(Pizza pizza)
        {
            ResponsePizzaDTO responsePizza = new ResponsePizzaDTO();
            responsePizza.Id = pizza.Id;
            responsePizza.CreatedAt = pizza.CreatedAt;
            responsePizza.Name = pizza.Name;
            responsePizza.Price = pizza.Price;

            return responsePizza;
        }



        // ------ Pizzas ------
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            var results = await repository.GetCustomers();
            List<Customer> customers = results.ToList();
            if (customers.Count <= 0)
            {
                return TypedResults.NoContent();
            }

            List<ResponseCustomerDTO> responseCustomers = new List<ResponseCustomerDTO>();

            foreach (Customer c in customers)
            {
                responseCustomers.Add(CreateResponseCustomerDTO(c));
            }

            return TypedResults.Ok(responseCustomers);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomerById(IRepository repository, int id)
        {
            try
            {
                var result = await repository.GetCustomerById(id);
                if (result is null)
                {
                    return TypedResults.NotFound("Customer Not Found");
                }

                ResponseCustomerDTO responseCustomer = CreateResponseCustomerDTO(result);

                return TypedResults.Ok(responseCustomer);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.ToString());
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateCustomer(IRepository repository, PostCustomerDTO model)
        {
            try
            {
                if (model == null)
                {
                    return TypedResults.BadRequest($"Invalid customer object");
                }

                if (String.IsNullOrEmpty(model.Name))
                {
                    return TypedResults.BadRequest($"Customer name is invalid or empty");
                }

                var newCustomer = await repository.CreateCustomer(new Customer { Name = model.Name });
                ResponseCustomerDTO responseCustomer = CreateResponseCustomerDTO(newCustomer);

                return TypedResults.Created($"https://localhost:7054/customers/{responseCustomer.Id}", responseCustomer);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest($"Invalid customer object - {ex}");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCustomer(IRepository repository, int id)
        {
            try
            {
                var target = await repository.DeleteCustomer(id);
                if (target is null)
                {
                    return TypedResults.NotFound("Customer Not Found");
                }

                //custom DTO
                ResponseCustomerDTO responseCustomer = CreateResponseCustomerDTO(target);

                return TypedResults.Ok(responseCustomer);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        public static ResponseCustomerDTO CreateResponseCustomerDTO(Customer customer)
        {
            ResponseCustomerDTO responseCustomer = new ResponseCustomerDTO();
            responseCustomer.Id = customer.Id;
            responseCustomer.Name = customer.Name;

            return responseCustomer;
        }
    }
}
