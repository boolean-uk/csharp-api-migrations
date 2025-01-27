using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Customer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("customer_name")]
        public string Name { get; set; }
    }
}
