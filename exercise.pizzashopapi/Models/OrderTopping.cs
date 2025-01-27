using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.pizzashopapi.Models
{
    [Table("order_topping")]
    public class OrderTopping
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("order")]
        [Column("order_id")]
        public int OrderId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        [ForeignKey("topping")]
        [Column("topping_id")]
        public int ToppingId { get; set; }

        // [JsonIgnore]
        public Topping Topping { get; set; }
    }
}
