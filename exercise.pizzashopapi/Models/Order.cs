using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        [ForeignKey("Pizzas")]
        public int PizzaId { get; set; }

        [Column("Driver")]
        public int DriverId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }



    }
}
