using exercise.pizzashopapi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("DeliveryDrivers")]
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Orders")]
        public List<OrderDTODriver> orders { get; set; }

    }
}
