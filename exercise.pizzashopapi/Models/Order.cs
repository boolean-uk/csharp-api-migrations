using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public ICollection<OrderToppings> OrderToppings { get; set; } // Add this line
        [NotMapped]
        public IEnumerable<Topping> Toppings { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStage OrderStage { get; set; }
    }
}
