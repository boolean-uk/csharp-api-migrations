using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("toppings")]
    public class Topping
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("price")]
        public decimal Price { get; set; }

        public List<OrderToppings> OrderToppings { get; set; } = new List<OrderToppings>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
