using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Column("pizza_id")]
        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }

        //[Column("quantity")]
        //public int Quantity { get; set; }

        //[Column("price")]
        //public decimal Price { get; set; }

        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }


    }
}
