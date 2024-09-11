namespace exercise.pizzashopapi.DTOs
{
    public class CreateOrderDTO
    {

        public int customerId { get; set; }

        public int pizzaId { get; set; }

        public string orderState { get; set; }

        public bool delivered { get; set; }
    }
}
