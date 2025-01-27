using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("customer")]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        public Customer customer { get; set; }

        [ForeignKey("pizza")]
        [Column("pizza_id")]
        public int PizzaId { get; set; }

        public Pizza pizza { get; set; }

        public List<OrderTopping>? OrderToppings { get; set; }

    }
}
