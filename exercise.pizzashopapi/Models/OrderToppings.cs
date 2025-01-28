namespace exercise.pizzashopapi.Models
{
    public class OrderToppings
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ToppingId { get; set; }
        //public int CustomerId { get; set; }
        //public int PizzaId { get; set; }
        public int OrderId { get; set; }

        public Order Order {  get; set; }
        public Topping Topping {  get; set; }

    }
}
