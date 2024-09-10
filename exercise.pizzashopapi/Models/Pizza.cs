using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    
    [Table("pizzas")]
    public class Pizza
    {
        [Key]
        [Column("id")] public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
    }
}