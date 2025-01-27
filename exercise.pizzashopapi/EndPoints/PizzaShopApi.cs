using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {

            var PizzaGroup = app.MapGroup("/pizza");

            PizzaGroup.MapGet("/", GetPizzas);
            PizzaGroup.MapGet("/{id}", GetPizza);
            PizzaGroup.MapPost("/", AddPizza);
            PizzaGroup.MapPut("/{id}", UpdatePizza);
            PizzaGroup.MapDelete("/{id}", DeletePizza);

            var CustomerGroup = app.MapGroup("/customer");
            CustomerGroup.MapGet("/", GetCustomers);
            CustomerGroup.MapGet("/{id}", GetCustomer);
            CustomerGroup.MapPost("/", AddCustomer);
            CustomerGroup.MapPut("/{id}", UpdateCustomer);

            var OrderGroup = app.MapGroup("/order");
            OrderGroup.MapGet("/", GetOrders);
            OrderGroup.MapGet("/{id}", GetOrder);
            OrderGroup.MapPost("/{customerId}/{pizzaId}", AddOrder);

        }

        #region Pizza
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repo, IMapper mapper )
        {
            var pizzas = await repo.Get();
            var pizzaDTOs = mapper.Map<List<PizzaListDTO>>(pizzas);
            return Results.Ok(pizzaDTOs);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPizza(IRepository<Pizza> repo, int id, IMapper mapper)
        {
            var pizza = await repo.GetById(id);
            if (pizza == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(mapper.Map<PizzaDTO>(pizza));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddPizza(IRepository<Pizza> repo, PizzaDTO pizza, IMapper mapper)
        {
            Pizza newPizza = new Pizza
            {
                Name = pizza.Name,
                Price = pizza.Price
            };

            var result = await repo.Add(newPizza);
            return Results.Ok(mapper.Map<PizzaDTO>(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdatePizza(IRepository<Pizza> repo, int id, PizzaDTO pizza, IMapper mapper)
        {
            var existingPizza = await repo.GetById(id);
            if (existingPizza == null)
            {
                return Results.NotFound();
            }
            existingPizza.Name = pizza.Name;
            existingPizza.Price = pizza.Price;
            var result = await repo.Update(existingPizza);
            return TypedResults.Ok(mapper.Map<PizzaDTO>(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeletePizza(IRepository<Pizza> repo, int id)
        {
            var existingPizza = await repo.GetById(id);
            if (existingPizza == null)
            {
                return Results.NotFound();
            }
            var result = await repo.Delete(id);
            return TypedResults.Ok(result);
        }

        #endregion

        #region Customer

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository<Customer> repo, IMapper mapper)
        {
            var customers = await repo
                .GetWithNestedIncludes( query => query.Include(c => c.Orders)
                .ThenInclude(o => o.Pizza));

            return Results.Ok(mapper.Map<List<CustomerDTO>>(customers));

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomer(IRepository<Customer> repo, int id, IMapper mapper)
        {
            var customer = await repo.GetQuery()
                .Include(c => c.Orders)
                .ThenInclude(o => o.Pizza)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(mapper.Map<CustomerDTO>(customer));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddCustomer(IRepository<Customer> repo, CustomerPut customer, IMapper mapper)
        {
            Customer newCustomer = new Customer
            {
                Name = customer.Name
            };
            var result = await repo.Add(newCustomer);
            return Results.Ok(mapper.Map<CustomerDTO>(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCustomer(IRepository<Customer> repo, int id, CustomerPut customer, IMapper mapper)
        {
            var existingCustomer = await repo.GetById(id);
            if (existingCustomer == null)
            {
                return Results.NotFound();
            }
            existingCustomer.Name = customer.Name;
            var result = await repo.Update(existingCustomer);
            return TypedResults.Ok(mapper.Map<CustomerDTO>(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCustomer(IRepository<Customer> repo, int id)
        {
            var existingCustomer = await repo.GetById(id);
            if (existingCustomer == null)
            {
                return Results.NotFound();
            }
            var result = await repo.Delete(id);
            return TypedResults.Ok(result);
        }

        #endregion

        #region Orders

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> repo, IMapper mapper)
        {
            var orders = await repo.GetQuery()
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .ToListAsync();
            return Results.Ok(mapper.Map<List<OrderDTO>>(orders));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrder(IRepository<Order> repo, int id, IMapper mapper)
        {
            var order = await repo.GetQuery()
                .Include(o => o.Customer)
                .Include(o => o.Pizza)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(mapper.Map<OrderDTO>(order));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddOrder(IRepository<Order> orderRepo, IRepository<Pizza> pizzaRepo, IRepository<Customer> customerRepo, int customerId, int pizzaId, IMapper mapper)
        {
            //var customer = await repo.GetById(customerId);
            var customer = await customerRepo.GetQuery()
                .FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                return Results.NotFound();
            }
            //var pizza = await repo.GetById(pizzaId);
            var pizza = await pizzaRepo.GetQuery()
                .FirstOrDefaultAsync(c => c.Id == pizzaId);

            if (pizza == null)
            {
                return Results.NotFound();
            }

            Order newOrder = new Order
            {
                CustomerId = customerId,
                PizzaId = pizzaId,
                Pizza = pizza,
                Customer = customer,

            };
            var result = await orderRepo.Add(newOrder);
            return Results.Ok(mapper.Map<OrderDTO>(result));
        }


        #endregion
    }
}
