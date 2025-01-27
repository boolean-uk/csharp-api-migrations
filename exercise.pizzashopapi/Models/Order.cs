using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
      public int Id { get; set; }
      public DateTime OrderTime { get; set; }
      public OrderStatus Status { get; set; }
      public PizzaStatus PizzaStatus { get; set; }
      public int CustomerId { get; set; }
      public Customer Customer { get; set; }
      
      public int PizzaId { get; set; }
      public Pizza Pizza { get; set; }

      public int? DeliveryDriverId { get; set; }
      public DeliveryDriver DeliveryDriver { get; set; }

    }
}
