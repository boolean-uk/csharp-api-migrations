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
        [Column("Pizzas")]
        public List<Pizza> pizzas {get; set;}
    }
}
