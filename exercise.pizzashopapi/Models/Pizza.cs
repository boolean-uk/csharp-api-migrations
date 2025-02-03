using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Models
{
    [Table("Pizza")]
    [PrimaryKey("pizzaId")]
    public class Pizza
    {
        [Column("pizzaId")]
        public int pizzaId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        
        [NotMapped]
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}