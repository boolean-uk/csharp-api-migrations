
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class DeliverEndpoint
    {
        public static void ConfigureDeliveryApi(this WebApplication app)
        {
            var deliveryGroup = app.MapGroup("BobsDelivery");

            deliveryGroup.MapGet("/DeliverPizza/{id}", MarkAsDelivered);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        private static async Task<IResult> MarkAsDelivered(IRepository repository, int id)
        {
            if (id < 1)
            {
                return TypedResults.BadRequest("ID cannot be less than 1");
            }
            try
            {
                return TypedResults.Ok(await repository.MarkOrderAsAsDelivered(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
            
        }
    }
}
