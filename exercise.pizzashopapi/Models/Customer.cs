using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
