using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public enum PizzaStatus
    {
        Received = 1,
        Prepared = 2,
        Cooked = 3,
        Transit = 4,
        Delivered = 5
    }

    [Table("orders")]
    public class Order
    {
        [Column("pizzaid")]
        public int PizzaId { get; set; }
        [Column("customerid")]
        public int CustomerId { get; set; }
        [Column("status")]
        public PizzaStatus Status { get; set; }
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
    }
}
