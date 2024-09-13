using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{ 

    public class Order
    {
        
        public int Id { get; set; }

        [Column("pizza_id")]
        [ForeignKey("pizzas")]
        public int PizzaId { get; set; }

        [Column("customer_id")]
        [ForeignKey("customers")]
        public int CustomerId { get; set; }
      
        public Pizza pizza { get; set; }
        public Customer customer { get; set; }
    }


}
