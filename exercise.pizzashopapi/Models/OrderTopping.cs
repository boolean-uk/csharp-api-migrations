using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.Models
{
    public class OrderTopping
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int ToppingId { get; set; }
        public Order Order { get; set; }
        public Topping Topping { get; set; }
    }
}
