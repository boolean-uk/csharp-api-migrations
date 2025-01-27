using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public int? DriverId { get; set; }
        
    }
}
