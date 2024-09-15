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

        public Pizza PizzaOnOrder { get; set; }
        public Customer CustomerOnOrder { get; set; }

        
    }
}
