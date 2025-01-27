using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("order_toppings")]
    public class OrderToppings
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Column("topping_id")]
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
    }
}
