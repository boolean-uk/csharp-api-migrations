using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace exercise.pizzashopapi.Models
{
    [Table("toppings")]
    public class Toppings
    {
        [Key]
        public int Id { get; set; }


        [Column("type")]
        public string Type { get; set; }

        public List<OrderTopping> ToppingOrders { get; set; } = new List<OrderTopping>();


    }
}
