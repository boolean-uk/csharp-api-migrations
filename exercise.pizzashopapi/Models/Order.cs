using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("customer_id")]
        public int CustomerId { get; set; } 
        public Customer Customer { get; set; }  

        [Column("pizza_id")]
        public int PizzaId { get; set; } 
        public Pizza Pizza { get; set; }
    }
}
