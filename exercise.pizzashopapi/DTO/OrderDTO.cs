using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        
        public int Id { get; set; }
        public string customer { get; set; }
        public string pizza { get; set; } = "";
        public List<string> toppings { get; set; } = new List<string>();

        public OrderDTO(Order order) 
        {
            Id = order.orderId;
            customer= order.customer.Name;
            pizza=$"{order.pizza.Name} {order.pizza.Price}";
            order.OrderToppings.ForEach(x => toppings.Add(x.topping.topping));
        
        }
    }
}
