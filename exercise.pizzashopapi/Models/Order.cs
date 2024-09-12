using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        [ForeignKey("pizzas")]
        public int PizzaID { get; set; }

        [ForeignKey("customers")]
        public int CustomerID { get; set; }

        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
    }
}
