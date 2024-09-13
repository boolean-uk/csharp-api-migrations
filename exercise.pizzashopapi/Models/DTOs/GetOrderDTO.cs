using exercise.pizzashopapi.Enum;

namespace exercise.pizzashopapi.Models.DTOs
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string CustomerName { get; set; }
        public string Pizza { get; set; }
        public decimal Price { get; set; }
    }
}
