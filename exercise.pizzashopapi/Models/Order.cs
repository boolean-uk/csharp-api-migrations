using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("Order")]
    public class Order
    {
        
        [Column("OrderId")]
        public int Id { get; set; }

        [ForeignKey("Pizza")]
        [Column("PizzaId")]
        public int PizzaId { get; set; }
        public Pizza pizza { get; set; }

        [ForeignKey("Customer")]
        [Column("CustomerId")]
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
    }
}
