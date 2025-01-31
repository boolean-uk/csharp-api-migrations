using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("toppings")]
    public class Topping
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OrderToppings> Orders { get; set; }
    }
}
