using Npgsql.PostgresTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{

    [Table("orders")]
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [ForeignKey("customer_id")]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [ForeignKey("piiza_id")]
        [Column("piiza_id")]
        public int PizzaId { get; set; }


    }
}
