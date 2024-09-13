using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId {get; set; }

        [ForeignKey(nameof(Pizza))]
        public int PizzaId { get; set; }
        public decimal Cost { get; set; }

    }
}
