using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.pizzashopapi.Models
{

    [Table("customers")]
    public class Customer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        //[JsonIgnore]
        //public List<Order> Orders { get; set; } = new List<Order>();
    }
}
