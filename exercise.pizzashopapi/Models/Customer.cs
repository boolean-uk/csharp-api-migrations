using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
    }
}
