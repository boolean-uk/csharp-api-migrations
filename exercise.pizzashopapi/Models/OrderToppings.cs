using exercise.pizzashopapi.DTO;

namespace exercise.pizzashopapi.Models
{
    public class OrderToppings
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }

        public OrderToppingWithoutToppingDTO NoTopping()
        {
            return new OrderToppingWithoutToppingDTO()
            {
                Id = this.Id,
                OrderId = this.OrderId,
                Order = this.Order
            };
        }
        public OrderToppingWithoutOrderDTO NoOrder()
        {
            return new OrderToppingWithoutOrderDTO()
            {
                Id = this.Id,
                ToppingId = this.ToppingId,
                Topping = this.Topping
            };

        }
    }
}
