using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Enums;
using exercise.pizzashopapi.Exceptions;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class ProductEnpoints
    {
        public static string Path { get; private set; } = "products";
        public static void ConfigureProductsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapGet("/", GetProducts);
            group.MapGet("/{id}", GetProduct);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetProducts(
            IRepository<Product, int> repository, 
            IMapper mapper,
            string? productType)
        {
            try
            {
                IEnumerable<Product> products = await repository.GetAll();

                if (!string.IsNullOrEmpty(productType))
                {
                    ProductType t;
                    if (!Enum.TryParse(productType, true, out t))
                    {
                        return TypedResults.BadRequest($"That is not a valid appointment type! Choose one of {string.Join(", ", Enum.GetValues<ProductType>())}");
                    }
                    products = products.Where(p => p.ProductType == t);
                }

                return TypedResults.Ok(mapper.Map<List<ProductView>>(products));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetProduct(IRepository<Product, int> repository, IMapper mapper, int id)
        {
            try
            {
                Product product = await repository.Get(id);
                return TypedResults.Ok(mapper.Map<ProductView>(product));
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
