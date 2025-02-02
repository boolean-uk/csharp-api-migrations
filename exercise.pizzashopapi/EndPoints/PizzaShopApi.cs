using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Repository;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizza = app.MapGroup("shop");

            pizza.MapGet("/pizza", GetPizzas);
            pizza.MapGet("/order", GetOrders);
            pizza.MapGet("/orderByCustomer{id}", GetOrderByCustomerId);

            pizza.MapPost("/orderforCustomer", AddOrderForCustomer);
            pizza.MapPost("/pizza", AddPizza);
            pizza.MapPost("/topping", AddTopping);

            pizza.MapPut("/updateOrder{id}", UpdateOrder);
            pizza.MapPut("/updatePizza{id}", UpdatePizza);

            pizza.MapDelete("/deleteOrder{id}", DeleteOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repository, IMapper mapper)
        {
            var pizzas = await repository.GetWithNestedIncludes(query =>
                query.Include(p => p.Orders)
                     .ThenInclude(a => a.Customer));

            var response = mapper.Map<List<PizzaNoListOrderDTO>>(pizzas);
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IRepository<Order> repository, IMapper mapper)
        {
            var orders = await repository.GetWithNestedIncludes(query =>
                query.Include(o => o.Customer)
                     .Include(o => o.Pizza));

            var response = mapper.Map<List<OrderDTO>>(orders);
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrderByCustomerId(IRepository<Order> repository, IMapper mapper, int id)
        {
            var orders = await repository.GetWithNestedIncludes(query =>
                query.Where(o => o.CustomerId == id)
                     .Include(o => o.Pizza).Include(o => o.Customer));

            var response = mapper.Map<List<OrderDTO>>(orders);
            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddOrderForCustomer(
            IRepository<Order> repository,
            IRepository<Customer> customerRepo,
            IRepository<Pizza> pizzaRepo,
            IMapper mapper,
            int customerId,
            int pizzaId)
        {
            var customer = await customerRepo.GetById(customerId);
            var pizza = await pizzaRepo.GetById(pizzaId);

            if (customer == null || pizza == null)
            {
                return TypedResults.BadRequest("Invalid customer or pizza ID");
            }

            var order = new Order
            {
                CustomerId = customerId,
                PizzaId = pizzaId,
                Customer = customer,
                Pizza = pizza,
                OrderStatus = OrderStatuses[Random.Next(OrderStatuses.Count)]
            };

            await repository.Add(order);
            var savedOrder = await repository.GetById(order.Id);

            if (savedOrder == null)
            {
                return TypedResults.Problem("Order was not saved correctly.");
            }

            var response = mapper.Map<OrderDTO>(savedOrder);
            return TypedResults.Created($"/shop/order/{savedOrder.Id}", response);
        }


        private static readonly Random Random = new Random();
        private static readonly List<string> OrderStatuses = new List<string>
        {
            "Preparing", "Baking", "Quality Check", "Out for Delivery", "Delivered"
        };

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddPizza(IRepository<Pizza> repository, IMapper mapper, PizzaDTO pizzaDto)
        {
            var pizza = mapper.Map<Pizza>(pizzaDto);
            await repository.Add(pizza);
            return TypedResults.Created($"/shop/pizza/{pizza.Id}", pizza);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddTopping(IRepository<Toppings> repository, IMapper mapper, AddToppingDTO toppingDto)
        {
            var topping = mapper.Map<Toppings>(toppingDto);
            await repository.Add(topping);
            return TypedResults.Created($"/shop/topping/{topping.Id}", topping);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateOrder(IRepository<Order> repository, IMapper mapper, int id, AddOrderDTO orderDto)
        {
            var existingOrder = await repository.GetById(id);
            if (existingOrder == null) return TypedResults.NotFound();

            mapper.Map(orderDto, existingOrder);
            await repository.Update(existingOrder);
            return TypedResults.Ok(existingOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdatePizza(IRepository<Pizza> repository, IMapper mapper, int id, PizzaNoListOrderDTO pizzaDto)
        {
            var existingPizza = await repository.GetById(id);
            if (existingPizza == null) return TypedResults.NotFound();

            mapper.Map(pizzaDto, existingPizza);
            await repository.Update(existingPizza);
            return TypedResults.Ok(existingPizza);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> DeleteOrder(IRepository<Order> repository, int id)
        {
            var existingOrder = await repository.GetById(id);
            if (existingOrder == null) return TypedResults.NotFound();

            await repository.Delete(existingOrder);
            return TypedResults.NoContent();
        }
    }
}
