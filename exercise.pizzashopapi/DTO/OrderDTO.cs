namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }
        public List<OTDTO> OrderToppingsDTOs { get; set; } = new List<OTDTO>();
    }
}
