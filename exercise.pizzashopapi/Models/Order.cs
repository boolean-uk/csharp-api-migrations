using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("pizza_id")]
        public int pizzaID { get; set; }
        [ForeignKey("customer_id")]
        public int customerId { get; set; }
        [Column("ordertime")]
        public DateTime OrderTime { get; } = DateTime.UtcNow;

    }
}
