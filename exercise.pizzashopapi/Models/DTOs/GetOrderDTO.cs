namespace exercise.pizzashopapi.Models.DTOs
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Pizza { get; set; }
        public decimal Price { get; set; }
    }
}
