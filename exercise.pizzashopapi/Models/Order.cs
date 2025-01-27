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

        [Column("status")]
        public string Status { get; set; } = "Preparing";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //[Column("estimated_delivery_time")]
        //public DateTime? EstimatedDeliveryTime { get; set; }

        [Column("cooking_started_at")]
        public DateTime? CookingStartedAt { get; set; }

        [Column("delivered_at")]
        public DateTime? DeliveredAt { get; set; }
    }
}
