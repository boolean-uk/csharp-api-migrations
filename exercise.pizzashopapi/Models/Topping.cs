

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Models
{
    [Table("Topping")]
    [PrimaryKey("toppingId")]
    public class Topping
    {
        [Column("toppingId")]
        public int toppingId { get; set; }
        [Column("topping")]
        public string topping {  get; set; }
        [Column("orderToppings")]
        public virtual List<OrderToppings> orderToppings { get; set; }
    }
}
