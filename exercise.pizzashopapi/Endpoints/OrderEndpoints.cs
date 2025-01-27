using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Exceptions;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Endpoints
{
    public static class OrderEndpoints
    {
        public static string Path { get; private set; } = "orders";
        public static void ConfigureOrdersEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapGet("/", GetOrders);
            group.MapPost("/", CreateOrder);
            group.MapGet("/{id}", GetOrder);
            group.MapPost("/{id}", AddTopping);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetOrders(
            IRepository<Order, int> repository, 
            IMapper mapper,
            string? customerId)
        {
            try
            {
                IEnumerable<Order> orders = await repository.GetAll(
                    q => q.Include(x => x.Customer),    
                    q => q.Include(x => x.Product),
                    q => q.Include(x => x.Toppings)
                );

                if (!string.IsNullOrEmpty(customerId))
                {
                    int id;
                    if (!int.TryParse(customerId, out id)) return TypedResults.BadRequest("The customerId must be of type int!");
                    orders = orders.Where(a => a.CustomerId == id);
                }

                return TypedResults.Ok(mapper.Map<List<OrderView>>(orders));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetOrder(IRepository<Order, int> repository, IMapper mapper, int id)
        {
            try
            {
                Order order = await repository.Get(id,
                    q => q.Include(x => x.Customer),
                    q => q.Include(x => x.Product),
                    q => q.Include(x => x.Toppings)
                );
                return TypedResults.Ok(mapper.Map<OrderView>(order));
            }
            catch (IdNotFoundException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateOrder(
            IRepository<Order, int> repository, 
            IRepository<Customer, int> customerRepository, 
            IRepository<Product, int> productRepository,
            IMapper mapper, 
            OrderPost entity)
        {
            try
            {
                Customer customer = await customerRepository.Get(entity.CustomerId);
                Product product = await productRepository.Get(entity.ProductId);

                Order order = await repository.Add(new Order
                {
                    CustomerId = customer.Id,
                    Customer = customer,
                    ProductId = product.Id,
                    Product = product,
                });
                return TypedResults.Created($"{Path}/{order.Id}", mapper.Map<OrderView>(order));
            }
            catch (IdNotFoundException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        public static async Task<IResult> AddTopping(
            IRepository<Order, int> repository,
            IRepository<Topping, int> toppingRepository,
            IMapper mapper,
            int id,
            OrderPostAddTopping entity)
        {
            try
            {
                Order order = await repository.Get(id, q => q.Include(x => x.Product).Include(x => x.Toppings));
                Topping topping = await toppingRepository.Get(entity.ToppingId);

                order.Toppings.Add(topping);
                await repository.Update(order);

                return TypedResults.Created($"{Path}/{order.Id}", mapper.Map<OrderView>(order));
            }
            catch (IdNotFoundException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
