using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models.Pizza
{
    [Table("PIZZAS")]
    public class Pizza
    {
        [Key]
        [Required]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("PRICE")]
        public decimal Price { get; set; }
    }
}