namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public DateTime OrderTime { get; set; }
        public OrderStatus Status { get; set; }
        public PizzaStatus PizzaStatus { get; set; }
        public CustomerDTO Customer { get; set; }
        public PizzaDTO Pizza { get; set; }
        public DeliveryDriverDTO? DeliveryDriver { get; set; }
    }
}
