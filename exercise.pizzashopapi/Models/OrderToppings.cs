namespace exercise.pizzashopapi.Models
{
    public class OrderToppings
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ToppingId { get; set; }
    }
}
