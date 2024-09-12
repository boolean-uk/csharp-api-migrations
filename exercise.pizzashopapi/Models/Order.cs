using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{

    [Table("orders")]
    public class Order
    {

       

        [ForeignKey("customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("pizzas")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

    }
}