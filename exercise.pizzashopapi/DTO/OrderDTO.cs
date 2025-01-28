using System.Security.Policy;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public OrderDTO(Order o)
        {
            this.OrderId = o.Id;
            this.PizzaID = o.PizzaId;
            this.PizzaName = o.Pizza.Name;
            this.CustomerId = o.CustomerId;
            
            this.Toppings = o.OrderToppings.Select(x => new OrderToppingDTO(x)).ToList();
            this.orderedAt = o.startTime;
        }
        public int OrderId { get; set; }
        public DateTime orderedAt { get; set; }
        public int CustomerId { get; set; }
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }
        public List<OrderToppingDTO> Toppings { get; set; }
    }
}
