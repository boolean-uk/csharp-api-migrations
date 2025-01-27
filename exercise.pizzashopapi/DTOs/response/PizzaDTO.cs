namespace exercise.pizzashopapi.DTOs.response
{
    public class PizzaDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<OrderPizzaDTO> Orders { get; set; } = new List<OrderPizzaDTO>();
    }
}
