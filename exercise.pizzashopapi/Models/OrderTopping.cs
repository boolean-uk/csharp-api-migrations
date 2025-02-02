using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("toppingOrder")]
    public class OrderTopping
    {

        [Key]
        public int Id { get; set; }

        [Column("topping_id")]
        [ForeignKey("toppings")]
        public int ToppingId { get; set; }


        [Column("order_id")]
        [ForeignKey("order")]
        public int OrderId { get; set; }


        public Toppings Topping { get; set; }
        public Order Order { get; set; }
    }
}
