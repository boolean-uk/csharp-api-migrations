using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public int customerId { get; set; }
      public int pizzaId { get; set; }
        
      
      public List<OrderToppings> toppings { get; set; }
        public Customer Customer { get; set; }

        
        public Pizza Pizza { get; set; }
    }
}
