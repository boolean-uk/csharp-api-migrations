using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class OrderToppingWithoutToppingDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
    public class OrderToppingWithoutOrderDTO
    {
        public int Id { get; set; }
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }

    }
}
