namespace exercise.pizzashopapi.DTOs
{
    public class UpdateOrderDTO
    {
        public int customerId { get; set; }
        public int pizzaId { get; set; }
        public string status { get; set; }
    }
}
