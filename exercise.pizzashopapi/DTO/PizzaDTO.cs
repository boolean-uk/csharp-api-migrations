using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class PizzaDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
