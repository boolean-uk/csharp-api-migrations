using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.pizzashopapi.Models
{

    [Table("pizzas")]
    public class Pizza
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

    }
}
