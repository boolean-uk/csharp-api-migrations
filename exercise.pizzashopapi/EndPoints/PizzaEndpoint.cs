using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaEndpoint
    {
        public static void ConfigurePizzaEndpoint(this WebApplication app)
        {
            var pizzas = app.MapGroup("pizzas");

            pizzas.MapGet("/GetAll", GetPizzas);
            pizzas.MapGet("/GetById{id}", GetPizza);
            pizzas.MapPost("/Create", CreatePizza);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetPizzas());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPizza(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetPizzaById(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePizza(IRepository repository, InputDTO data)
        {
            try
            {
                //Check if the data is bad
                if (data.Name == string.Empty)
                {
                    return TypedResults.BadRequest();
                }

                //Create a new Pizza
                Pizza pizza = new Pizza() { Name = data.Name };
                var result = await repository.AddPizza(pizza);

                //Response
                return TypedResults.Created($"http://localhost:7138/pizzas/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
