using AutoMapper;
using exercise.pizzashopapi.DTOs.request;
using exercise.pizzashopapi.DTOs.response;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaGroup = app.MapGroup("/pizza");

            pizzaGroup.MapGet("/", GetAllPizza);
            pizzaGroup.MapGet("/{id}", GetPizza);
            pizzaGroup.MapPost("/", CreatePizza);
            pizzaGroup.MapPut("/{id}", EditPizza);
            pizzaGroup.MapDelete("/{id}", DeletePizza);

            var customerGroup = app.MapGroup("/customer");
            customerGroup.MapGet("/", GetAllCustomers);
            customerGroup.MapGet("/{id}", GetCustomer);
            customerGroup.MapPost("/", CreateCustomer);
            customerGroup.MapPost("/{customerId}/{pizzaId}", OrderPizza);
            customerGroup.MapPut("/{id}", EditCustomer);
            customerGroup.MapDelete("/{id}", DeleteCustomer);

            var orderGroup = app.MapGroup("/orders");
            orderGroup.MapGet("/", GetAllOrders);
            orderGroup.MapGet("/{id}", GetOrder);
            orderGroup.MapDelete("/{id}", DeleteOrder);

            var toppingGroup = app.MapGroup("/topping");
            toppingGroup.MapGet("/", GetAllToppings);
            toppingGroup.MapGet("/{id}", GetTopping);
            toppingGroup.MapPost("/", CreateTopping);
            toppingGroup.MapDelete("/{id}", DeleteTopping);

        }

        private static async Task<IResult> GetAllPizza(IRepository<Pizza> repository, IMapper mapper) 
        {
            var pizzas = await repository.GetWithNestedIncludes(query =>
                query.Include(pizzas => pizzas.Orders)
                    .ThenInclude(o => o.Customer)
                    );
            var response = mapper.Map<List<PizzaDTO>>(pizzas);
            return TypedResults.Ok(response);
        }

        private static async Task<IResult> GetAllCustomers(IRepository<Customer> repository, IMapper mapper)
        {
            var customer = await repository.GetWithNestedIncludes(query =>
                query.Include(cust => cust.Orders)
                    .ThenInclude(o => o.Pizza)
                    );
            var response = mapper.Map<List<CustomerDTO>>(customer);
            return TypedResults.Ok(response);
        }

        private static async Task<IResult> GetPizza(IRepository<Pizza> repository, int id, IMapper mapper) 
        {
            Pizza pizza = await repository.GetQueryable()
                .Include(p => p.Orders)
                .ThenInclude(o => o.Customer)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if(pizza == null)
            {
                return TypedResults.NotFound($"Pizza with ID {id} not found");
            }
            return TypedResults.Ok(mapper.Map<PizzaDTO>(pizza));
        }


        private static async Task<IResult> EditPizza(IRepository<Pizza> repository, int id, PizzaPost pizza, IMapper mapper)
        {
            if(pizza == null)
            {
                return TypedResults.BadRequest("Pizza is null");
            }
            Pizza pizzaToUpdate = await repository.GetQueryable()
                .Include(c => c.Orders)
                .ThenInclude(o => o.Customer)
                .FirstOrDefaultAsync(p => p.Id == id);
            if(pizzaToUpdate == null)
            {
                return TypedResults.NotFound($"Customer with ID {id} not found");
            }
            pizzaToUpdate.Price = pizza.Price;
            pizzaToUpdate.Name = pizza.Name;
            await repository.Update(pizzaToUpdate);
            return TypedResults.Ok(mapper.Map<PizzaDTO>(pizzaToUpdate));
        }

        private static async Task<IResult> DeletePizza(IRepository<Pizza> pizzaRepository, IRepository<Order> orderRepository, int id, IMapper mapper)
        {
            Pizza pizzaToDelete = await pizzaRepository.GetById(id);
            if(pizzaToDelete == null)
            {
                return TypedResults.NotFound($"Customer with ID {id} not found");
            }
            var pizzaOrders = orderRepository.GetQueryable()
                .Where(o => o.PizzaId == id).ToList();
            foreach (Order order in pizzaOrders)
            {
                await orderRepository.Delete(order.Id);
            }
            await pizzaRepository.Delete(id);
            return TypedResults.Ok(mapper.Map<PizzaDTO>(pizzaToDelete));
        }
        private static async Task<IResult> CreatePizza(IRepository<Pizza> repository, PizzaPost payload, IMapper mapper)
        {
            Pizza pizza = new Pizza(payload.Name, payload.Price);
            var inserted = await repository.Insert(pizza);
            return TypedResults.Created(
                $"https://localhost:7010/pizza/{inserted.Id}",
                new PizzaDTO { Name = inserted.Name, Price = inserted.Price });
        }

        private static async Task<IResult> GetCustomer(IRepository<Customer> repository, int id, IMapper mapper)
        {
            Customer customer = await repository.GetQueryable()
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if(customer == null)
            {
                return TypedResults.NotFound($"Customer with ID {id} not found");
            }
            return TypedResults.Ok(mapper.Map<CustomerDTO>(customer));
        }

        private static async Task<IResult> CreateCustomer(IRepository<Customer> repository, CustomerPut payload, IMapper mapper)
        {
            Customer customer = new Customer(payload.Name);
            var inserted = await repository.Insert(customer);
            return TypedResults.Created($"https://localhost:7010/customer/{inserted.Id}",
                new CustomerDTO { Name = inserted.Name });
        }
        private static async Task<IResult> OrderPizza(IRepository<Order> orderRepository, IRepository<Pizza> pizzaRepository, IRepository<Customer> customerRepository, OrderPost payload, IMapper mapper)
        {
            Customer customer = await customerRepository.GetById(payload.CustomerId);
            Pizza pizza = await pizzaRepository.GetById(payload.PizzaId);

            if(customer == null || pizza == null)
            {
                return TypedResults.BadRequest("Customer or Pizza not found");
            }
            Order order = new Order(payload.PizzaId, payload.CustomerId, pizza, customer);
            await orderRepository.Insert(order);
            return TypedResults.Ok(mapper.Map<OrderPizzaDTO>(order));
        }
        private static async Task<IResult> EditCustomer(IRepository<Customer> repository, int id, CustomerPut customer, IMapper mapper)
        {
            if(customer == null)
            {
                return TypedResults.BadRequest("Customer is null");
            }
            Customer customerToUpdate = await repository.GetQueryable()
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (customerToUpdate == null)
            {
                return TypedResults.NotFound($"Customer with ID {id} not found");
            }
            customerToUpdate.Name = customer.Name;
            await repository.Update(customerToUpdate);          
            return TypedResults.Ok(mapper.Map<CustomerDTO>(customerToUpdate));
        }

        private static async Task<IResult> DeleteCustomer(IRepository<Customer> customerRepository, IRepository<Order> orderRepository, int id, IMapper mapper)
        {
            Customer customerToDelete = await customerRepository.GetById(id);
            if(customerToDelete == null)
            {
                return TypedResults.NotFound($"Customer with ID {id} not found");
            }
            var customerOrders = orderRepository.GetQueryable()
                .Where(o => o.CustomerId == id).ToList();
            foreach(Order order in customerOrders)
            {
                await orderRepository.Delete(order.Id);
            }
            await customerRepository.Delete(id);
            return TypedResults.Ok(mapper.Map<CustomerDTO>(customerToDelete));
        }
        private static async Task<IResult> GetOrder(IRepository<Order> repository, int id, IMapper mapper)
        {
            Order order = await repository.GetQueryable()
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);
            if(order == null)
            {
                return TypedResults.NotFound($"Order with ID {id} not found");
            }
            string status = "";
            if (DateTime.Compare(order.CreatedAt, DateTime.Now) < 3) { status = "Preparing"; }
            else if (DateTime.Compare(order.CreatedAt, DateTime.Now) < 12) { status = "Cooking"; }
            else status = "Delivering";

            OrderCustomerDTO ocDTO = new OrderCustomerDTO()
            {
                PizzaId = order.PizzaId,
                PizzaName = order.Pizza.Name,
                OrderStatus = status
            };
            return TypedResults.Ok(ocDTO);
        }

        private static async Task<IResult> GetAllOrders(IRepository<Order> repository, IMapper mapper) 
        {
            List<Order> orders = await repository.GetQueryable()
                .Include(o => o.Pizza)
                .Include(o => o.Customer)
                .ToListAsync();
            return TypedResults.Ok(mapper.Map<List<OrderDTO>>(orders));
        }
        private static async Task<IResult> DeleteOrder(IRepository<Order> repository, int id, IMapper mapper)
        {
            Order order = await repository.GetQueryable()
                 .Include(o => o.Pizza)
                 .Include(o => o.Customer)
                 .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return TypedResults.NotFound($"Order with ID {id} not found");
            }
            await repository.Delete(id);

            return TypedResults.Ok(mapper.Map<OrderDTO>(order));
        }

        private static async Task<IResult> GetTopping(IRepository<Topping> repository, int id, IMapper mapper)
        {
            Topping topping = await repository.GetById(id);
            if (topping == null)
            {
                return TypedResults.NotFound($"Topping with ID {id} not found");
            }
            return TypedResults.Ok(mapper.Map<ToppingDTO>(topping));
        }

        private static async Task<IResult> GetAllToppings(IRepository<Topping> repository, IMapper mapper)
        {
            var orders = await repository.GetAll();
            return TypedResults.Ok(mapper.Map<List<ToppingDTO>>(orders));
        }

        private static async Task<IResult> DeleteTopping(IRepository<Topping> toppingRepository, IRepository<Order> orderRepository, int id, IMapper mapper)
        {
            Topping toppingToDelete = await toppingRepository.GetById(id);
            if (toppingToDelete == null)
            {
                return TypedResults.NotFound($"Topping with ID {id} not found");
            }
            var toppingOrders = orderRepository.GetQueryable()
               .Any(o => o.ToppingOrders.Any(o => o.ToppingId == id));
            if(toppingOrders)
            {
                return TypedResults.BadRequest(TypedResults.BadRequest("Order(s) contains topping, could not delete"));
            }
            await toppingRepository.Delete(id);
            return TypedResults.Ok(mapper.Map<ToppingDTO>(toppingToDelete));
        }

        private static async Task<IResult> CreateTopping(IRepository<Topping> repository, string payload, IMapper mapper)
        {
            Topping topping = new Topping(){ Name = payload };
            var inserted = await repository.Insert(topping);
            return TypedResults.Created($"https://localhost:7010/customer/{inserted.Id}",
                new ToppingDTO { Name = inserted.Name });
        }



    }
}
