using exercise.pizzashopapi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("Order")]
    public class Order
    {
        [Column("customerid")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Column("pizzaid")]
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }

        [Column("orderStatus")]
        public OrderStatus OrderStatus { get; set; }

        public DateTime TimeOfOrder { get; set; } = DateTime.UtcNow;
       
    }
}
