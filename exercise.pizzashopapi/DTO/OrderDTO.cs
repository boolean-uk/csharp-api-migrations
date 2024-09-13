using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public record CreateOrderDTO(int CustomerId, int PizzaId)
    {
          
    }
    public record GetOrderDTO(string CustomerName, string PizzaName, decimal Price)
    {
        
    }
    
}
