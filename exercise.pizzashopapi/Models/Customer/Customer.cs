using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models.Customer
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        [Key]
        [Required]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}
