using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO.Request
{
    public class OrderPost
    {
        public int Quantity { get; set; }
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }
    }
}
