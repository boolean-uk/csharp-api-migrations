using System.ComponentModel.DataAnnotations.Schema;
using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int PizzaId { get; set; }
        public Customer? Customer { get; set; }
        public Pizza Pizza { get; set; }
        //public List<int>? ToppingIds { get; set; }
        public List<Topping>? Toppings { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Delivered { get; set; }
        [NotMapped]
        public OrderStatus Status
        {
            get
            {
                if (Delivered)
                {
                    return OrderStatus.Delivered;
                }
                return (DateTime.UtcNow - OrderDate) switch
                {
                    var d when d.TotalMinutes < 3 => OrderStatus.Preparing,
                    var d when d.TotalMinutes < 12 => OrderStatus.Cooking,
                    _ => OrderStatus.Delivering
                };
            }
        }

        public Order()
        {
            OrderDate = DateTime.UtcNow;
        }
    }
}
