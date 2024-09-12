using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace exercise.pizzashopapi.DTOs
{
    public class ResponseOrderDTO
    {
        public DateTime CreatedAt { get; set; }
        public string OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }

        public string GetOrderStatus(DateTime createdAt)
        {
            StringBuilder orderStatus = new StringBuilder(string.Empty);
            if (DateTime.UtcNow < createdAt + TimeSpan.FromMinutes(3))
            {
                orderStatus.AppendLine("Pizza is being prepared.");
            }

            else if ((DateTime.UtcNow >= createdAt + TimeSpan.FromMinutes(3)) && (DateTime.UtcNow < createdAt + TimeSpan.FromMinutes(12)))
            {
                orderStatus.AppendLine("Pizza is in the oven.");
            }

            else if (DateTime.UtcNow >= createdAt + TimeSpan.FromMinutes(12))
            {
                orderStatus.AppendLine("Pizza is done and being delivered to you shortly.");
            }
            return orderStatus.ToString();
        }
    }

    public class PostOrderDTO
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
    }
}
