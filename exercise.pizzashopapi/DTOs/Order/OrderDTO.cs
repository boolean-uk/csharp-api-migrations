using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.DTOs.Order
{
    public class OrderDTO
    {
        public string Customer { get; set; }
        public string Pizza { get; set; }
        public decimal Total { get; set; }

        public string OrderStatus { get; set; }

    }
}
