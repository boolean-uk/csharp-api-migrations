using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models.Order
{
    [Table("ORDERS")]
    public class Order
    {
        [Required]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("PIZZAS")]
        [Column("CUSTOMERID")]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("PIZZAS")]
        [Column("PIZZAID")]
        public int PizzaId { get; set; }

        public DateTime orderTime { get; set; }
        public bool isDelivered { get; set; }


    }
}
