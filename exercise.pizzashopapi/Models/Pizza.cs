using System.ComponentModel.DataAnnotations.Schema;
using exercise.pizzashopapi.Repository;

namespace exercise.pizzashopapi.Models
{
    [Table("pizza")]
    public class Pizza
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("pizza_name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
    }
}