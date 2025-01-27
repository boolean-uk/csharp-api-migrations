using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Enums;
using exercise.pizzashopapi.Exceptions;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class ToppingEnpoints
    {
        public static string Path { get; private set; } = "toppings";
        public static void ConfigureToppingsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapGet("/", GetToppings);
            group.MapGet("/{id}", GetTopping);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetToppings(
            IRepository<Topping, int> repository, 
            IMapper mapper)
        {
            try
            {
                IEnumerable<Topping> toppings = await repository.GetAll();
                return TypedResults.Ok(mapper.Map<List<ToppingView>>(toppings));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetTopping(IRepository<Topping, int> repository, IMapper mapper, int id)
        {
            try
            {
                Topping topping = await repository.Get(id);
                return TypedResults.Ok(mapper.Map<ToppingView>(topping));
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
