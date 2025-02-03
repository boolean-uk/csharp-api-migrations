using System.ComponentModel.DataAnnotations.Schema;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Models
{
    [Table("OrderToppings")]
    [PrimaryKey("orderToppingId")]
    public class OrderToppings
    {
        [Column("orderToppingId")]
        public int orderToppingId { get; set; }
        [Column("orderId")]
        public int orderId { get; set; }
        [NotMapped]
        public virtual Order order { get; set; }
        [Column("toppingId")]
        public int toppingId { get; set; }
        [NotMapped]
        public virtual Topping topping { get; set; }
    }
}
