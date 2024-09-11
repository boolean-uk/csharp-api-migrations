using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("Pizza_Id")]
        public int PizzaId { get; set; }

        [ForeignKey("Customer_Id")]
        public int CustomerId { get; set; }

        [Column("ReceivedOrder")]
        public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;
    }
}
