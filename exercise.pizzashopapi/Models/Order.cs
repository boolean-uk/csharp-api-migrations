using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        [ForeignKey("customer")]
        public int CustomerId { get; set; }
        [ForeignKey("pizza")]
        public int PizzaId { get; set; }
        [Column("delivery_adress")]
        public string DeliveryAddress { get; set; }
        [Column("Status")]
        public OrderStatus Status { get; set; }
        public Pizza PizzaOnOrder { get; set; }
        public Customer CustomerOnOrder { get; set; }

        
    }

    public enum OrderStatus
    {
        Preparing,
        Cooking,
        OnRoute,
        Delivered
    }
}
