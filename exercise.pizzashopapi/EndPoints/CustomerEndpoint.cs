using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class CustomerEndpoint
    {
        public static void ConfigureCustomerEndpoint(this WebApplication app)
        {
            var customers = app.MapGroup("customers");

            customers.MapGet("/GetAll", GetCustomers);
            customers.MapGet("/GetById{id}", GetCustomer);
            customers.MapPost("/Create", CreateCustomer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetCustomers());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCustomer(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetCustomerById(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCustomer(IRepository repository, InputDTO data)
        {
            try
            {
                //Check if the data is bad
                if(data.Name == string.Empty)
                {
                    return TypedResults.BadRequest();
                }

                //Create a new customer
                Customer customer = new Customer() { Name = data.Name };
                var result = await repository.AddCustomer(customer);
                
                //Response
                return TypedResults.Created($"http://localhost:7138/customers/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
