using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("Pizzas")]
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Pizza")]
        public string Name { get; set; }
        [Required]
        [Column("Price")]
        public decimal Price { get; set; }
    }
}