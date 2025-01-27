using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("order_toppings")]
    public class OrderToppings
    {
        [Column("order_id")]
        [ForeignKey("orders")]

        public int OrderId { get; set; }
        [Column("topping_id")]
        [ForeignKey("toppings")]
        public int ToppingsId { get; set; }
        public Order Order { get; set; }
        public Toppings Toppings { get; set; }
    }
}
