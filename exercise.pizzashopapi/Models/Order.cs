using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("pizza_id")]
        public int PizzaId { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; } 
        public List<OrderToppings> OrderToppings { get; set; }
        public List<Toppings> Toppings { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public static OrderStatus GetOrderStatus(DateTime createdAt, DateTime currentTime)
        {
            var elapsedMinutes = (currentTime - createdAt).TotalMinutes;

            if (elapsedMinutes <= 3)
                return OrderStatus.Preparing;
            else if (elapsedMinutes <= 15)
                return OrderStatus.Cooking;
            else
                return OrderStatus.Ready;
        }
    }

    public enum OrderStatus
    {
        Preparing,
        Cooking,
        Ready,
        Delivered
    }

    
}
