using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public record CreateOrderDTO(int CustomerId, int PizzaId, decimal PizzaPrice)
    {
          
    }
    public record GetOrderDTO(string CustomerName, string PizzaName, decimal PizzaPrice)
    {
        
    }
    public class OrderResponse()
    {
        public List<string> Orders { get; set; } = new List<string>();
    }
}
