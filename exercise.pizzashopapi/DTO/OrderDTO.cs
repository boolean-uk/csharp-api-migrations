using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public string EstimatedDelivery {  get; set; }
        public int CustomerId { get; set; }
        public string Customer {  get; set; }
        public int PizzaId { get; set; }
        public string Pizza { get; set; }
    }
}
