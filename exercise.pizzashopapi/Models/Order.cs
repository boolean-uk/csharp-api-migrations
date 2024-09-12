using exercise.pizzashopapi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        [Column("orderdate")]
        public DateTime OrderDate { get; set; }
        [Column("status")]
        public OrderStatus Status { get; set; }
        [Column("estimatedDelivery")]
        public DateTime EstimatedDelivery {  get; set; }
        [ForeignKey("Pizza")]
        [Column("pizzaid")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        [ForeignKey("Customer")]
        [Column("customerid")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
