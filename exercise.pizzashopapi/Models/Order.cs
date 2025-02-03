using System.ComponentModel.DataAnnotations.Schema;
using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Models
{
    [Table("Order")]
    [PrimaryKey("orderId")]
    public class Order
    {
        [Column("orderId")]
        public int orderId { get; set; }
        [Column("Customer")]
        public virtual Customer customer {get; set;}
        [Column("CustomerId")]
        public int customerId { get; set;  }
        [Column("PizzaId")]
        public int pizzaId { get; set; }
       [Column("Pizzas")]
        public virtual Pizza pizza {get; set;}
        [NotMapped]
        public virtual List<OrderToppings> OrderToppings { get; set; }
    }
}
