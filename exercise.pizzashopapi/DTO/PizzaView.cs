using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class PizzaView
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
