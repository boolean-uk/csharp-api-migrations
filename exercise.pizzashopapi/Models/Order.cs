using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [PrimaryKey(nameof(PizzaId), nameof(CustomerId))]
    public class Order
    {
        public int PizzaId { get; set; }
        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }

        public DateTime OrderedAt { get; set; }

        public string PizzaStatus { get; set; }

        public string UpdatePizzaStatus()
        {
            if (PizzaStatus == "Delivered")
            {
                return PizzaStatus;
            }

            double minutesSinceOrdering = DateTime.UtcNow.Subtract(OrderedAt).TotalMinutes;

            if (minutesSinceOrdering < 3.0)
            {
                return "Preparing";
            }
            else if (minutesSinceOrdering < 15.0)
            {
                return "Cooking";
            }
            else 
            {
                return "Delivering";
            }
        }
    }
}
