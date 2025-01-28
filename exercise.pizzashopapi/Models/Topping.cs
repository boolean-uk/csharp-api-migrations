namespace exercise.pizzashopapi.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public List<OrderToppings> OrderToppings { get; set; }
    }
}
