using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        
        public int Id { get; set; }
        public string customer { get; set; }
        public List<string> pizzas { get; set; } = new List<string>();

        public OrderDTO(Order order) 
        {
            Id = order.Id;
            customer= order.customer.Name;
            order.pizzas.ForEach(x=> pizzas.Add($"{x.Name} {x.Price}"));
        
        }
    }
}
