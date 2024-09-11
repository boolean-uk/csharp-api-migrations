using System.Runtime.CompilerServices;

namespace exercise.pizzashopapi.Models.Pizza
{
    public static class PizzaMapper
    {
        public static PizzaDTO MapToDTO(this Pizza pizza)
        {
            return new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price
            };
        }

        public static List<PizzaDTO> MapListToDTO(this List<Pizza> pizza)
        {
            return pizza.Select(pizza => new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price
            }).ToList();
        }
    }
}
