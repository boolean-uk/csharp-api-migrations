using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Exceptions;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Endpoints
{
    public static class CustomerEndpoints
    {
        public static string Path { get; private set; } = "customers";
        public static void ConfigureCustomersEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapGet("/", GetCustomers);
            group.MapPost("/", CreateCustomer);
            group.MapGet("/{id}", GetCustomer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetCustomers(IRepository<Customer, int> repository, IMapper mapper)
        {
            try
            {
                IEnumerable<Customer> customers = await repository.GetAll(
                    q => q.Include(x => x.Orders).ThenInclude(x => x.Toppings),
                    q => q.Include(x => x.Orders).ThenInclude(x => x.Product)
                );
                return TypedResults.Ok(mapper.Map<List<CustomerView>>(customers));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetCustomer(IRepository<Customer, int> repository, IMapper mapper, int id)
        {
            try
            {
                Customer customer = await repository.Get(id,
                    q => q.Include(x => x.Orders).ThenInclude(x => x.Toppings),
                    q => q.Include(x => x.Orders).ThenInclude(x => x.Product)
                );
                return TypedResults.Ok(mapper.Map<CustomerView>(customer));
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
        public static async Task<IResult> CreateCustomer(
            IRepository<Customer, int> repository, 
            IRepository<Customer, int> customerRepository, 
            IRepository<Product, int> productRepository,
            IMapper mapper, 
            CustomerPost entity)
        {
            try
            {
                Customer customer = await repository.Add(new Customer
                {
                    Name = entity.Name
                });
                customer = await customerRepository.Add(customer);
                return TypedResults.Created($"{Path}/{customer.Id}", mapper.Map<CustomerView>(customer));
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
