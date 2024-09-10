using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public DateTime Ordered { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
