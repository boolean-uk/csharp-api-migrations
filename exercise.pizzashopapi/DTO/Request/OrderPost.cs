using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class OrderPost
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
    }
}
