using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Models
{
    [Table("Customer")]
    [PrimaryKey("customerId")]
    public class Customer
    {
        [Column("customerId")]
        public int customerId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Orders")]
        public virtual List<Order> Orders { get; set; } = new List<Order>();
        
    }
}
