using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        public Order(int customerId, int pizzaId)
        {
            CustomerId = customerId;
            PizzaId = pizzaId;
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("customerId")]
        [Column("customer id")]
        public int CustomerId { get; set; }

        [ForeignKey("pizzaId")]
        [Column("pizza id")]
        public int PizzaId { get; set; }

        
    }
}
