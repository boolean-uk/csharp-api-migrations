using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Column("customer_id")]
        [ForeignKey("customer")]
        public int CustomerId { get; set; }

        [Column("pizza_id")]
        [ForeignKey("pizza")]
        public int PizzaId { get; set; }

        public Customer Customer { get; set; }

        public Pizza Pizza { get; set; }

        public List<OrderTopping> OrderToppings { get; set; } = new List<OrderTopping>();

        public string OrderStatus { get; set; }
    }
}
