using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        public Order(int customerId, int pizzaId)
        {
            CustomerId = customerId;
            PizzaId = pizzaId;
            TimeOrdered =  DateTime.Now.ToUniversalTime();
            TimeSinceOrdered = 0.0;
            Status = "Preparing pizza";
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("customerId")]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [ForeignKey("pizzaId")]
        [Column("pizza_id")]
        public int PizzaId { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("Time_since_ordered")]
        public double TimeSinceOrdered { get; set; }

        public DateTime TimeOrdered { get; set; }
    }
}
