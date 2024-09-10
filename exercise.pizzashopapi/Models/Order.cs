using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("customerId")]
        [ForeignKey("customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Column("pizzaId")]
        [ForeignKey("pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        
    }
}
