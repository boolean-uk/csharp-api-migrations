namespace exercise.pizzashopapi.DTO
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public List<int> ToppingIds { get; set; }
    }
}
