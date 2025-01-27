namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderToppingsDTO> OrderToppingsDTOs { get; set; } = new List<OrderToppingsDTO>();
    }
}
