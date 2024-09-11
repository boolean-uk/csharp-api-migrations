using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class OrderView
    {
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }
    }
}
