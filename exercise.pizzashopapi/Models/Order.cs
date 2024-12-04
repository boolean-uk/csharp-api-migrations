using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }

        public DateTime StartTime { get; set; }

        public bool IsDelivered { get; set; }
    }
}
