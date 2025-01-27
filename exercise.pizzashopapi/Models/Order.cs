using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        [Column("id")]
        public int OrderId { get; set; }

        [ForeignKey("customer_id")]
        public int CustomerId { get; set; }

        [ForeignKey("pizza_id")]
        public int PizzaId { get; set; }
        
    }
}
