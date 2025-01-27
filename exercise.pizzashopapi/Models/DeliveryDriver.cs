using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("delivery_drivers")]
    public class DeliveryDriver
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
