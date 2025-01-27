using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("pizza_id")]
        public int PizzaId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
        public List<OrderTopping> Toppings { get; set; } = new();
        public List<OrderProduct> Products { get; set; } = new();

    }
}
