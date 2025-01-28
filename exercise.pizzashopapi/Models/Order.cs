using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Models
{
    [Table("Order")]
    [PrimaryKey("Id")]
    public class Order
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Customer")]
        public Customer customer {get; set;}
        [Column("CustomerId")]
        public int customerId { get; set;  }
        [Column("PizzaId")]
        public int pizzaId { get; set; }
       [Column("Pizzas")]
        public Pizza pizza {get; set;}
    }
}
