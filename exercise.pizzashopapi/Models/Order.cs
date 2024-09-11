using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("pickup")]
        public DateTime Pickup {  get; set; }

        [Column("stage")]
        public string Stage { get; set; }

        [ForeignKey("pizzaid")]
        public int PizzaId { get; set; }

        [ForeignKey("customerid")]
        public int CustomerId { get; set; }

        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }


    }
}