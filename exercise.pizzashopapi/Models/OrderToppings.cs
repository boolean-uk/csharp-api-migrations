using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("order_toppings")]
    public class OrderToppings
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ToppingId { get; set; }

        public Order Order {  get; set; }
        public Topping Topping { get; set; }
    }
}
