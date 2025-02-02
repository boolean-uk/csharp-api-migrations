using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Models
{
    [Table("Pizza")]
    [PrimaryKey("Id")]
    public class Pizza
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        
        [NotMapped]
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}