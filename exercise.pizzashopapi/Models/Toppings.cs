using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("toppings")]
    public class Toppings
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public List<OrderToppings> OrderToppings { get; set; }
        public List<Order> Order { get; set; } = [];
    }
}
