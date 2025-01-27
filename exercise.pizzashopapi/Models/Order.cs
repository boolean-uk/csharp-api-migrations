using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public int? DeliveryDriverId { get; set; }
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public DeliveryDriver DeliveryDriver { get; set; }
        public List<OrderMenuItem> OrderMenuItems { get; set; } = new List<OrderMenuItem>();
    }
}
