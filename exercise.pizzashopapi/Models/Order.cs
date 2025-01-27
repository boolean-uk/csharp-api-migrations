using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        [ForeignKey("customer_id")]
        public int CustomerId { get; set; }

        [ForeignKey("pizza_id")]
        public int PizzaId { get; set; }

        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        
    }
}
