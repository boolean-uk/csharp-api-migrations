using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("order")]
    public class Order
    {
        [Column("createdAt")]
        public DateTime CreatedAt { get; set; }
    
        [Column("delivered")]
        public bool Delivered { get; set; }

        //[ForeignKey("Customer")]
        [ForeignKey("customerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("pizzaId")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
