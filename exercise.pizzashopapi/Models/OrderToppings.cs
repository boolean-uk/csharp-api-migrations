namespace exercise.pizzashopapi.Models
{
    public class OrderToppings
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ToppingId { get; set; }
        public Toppings Topping { get; set; }
    }
}
