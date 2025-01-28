using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        
        public int Id { get; set; }
        public string customer { get; set; }
        public string pizza { get; set; } = "";

        public OrderDTO(Order order) 
        {
            Id = order.Id;
            customer= order.customer.Name;
            pizza=$"{order.pizza.Name} {order.pizza.Price}";
        
        }
    }
}
