using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("Pizza")]
    public class Pizza
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("pizza_name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
    }
}