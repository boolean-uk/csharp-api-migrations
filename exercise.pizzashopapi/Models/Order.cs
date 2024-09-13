using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("Orders")]
    public class Order
    {

        [Column("pizzaid")]
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        [Column("customerid")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column("ordertime")]
        public DateTime OrderTime { get; set; }

        [Column("status")]
        public string Status { get; set; }

    }
}
