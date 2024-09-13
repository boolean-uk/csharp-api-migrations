namespace exercise.pizzashopapi.DTOs
{
    public class GetPizzaDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PizzaOrderDTO Order { get; set; }
    }
}
