using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Models
{
    [Table("Customer")]
    [PrimaryKey("Id")]
    public class Customer
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Orders")]
        public List<Order> Orders { get; set; } = new List<Order>();
        
    }
}
