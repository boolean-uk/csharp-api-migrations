using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("customer")]
    public class Customer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("customer_name")]
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order> ();
    }
}
