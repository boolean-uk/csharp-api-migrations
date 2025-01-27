using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class OrderPost
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
    }
}
