using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
