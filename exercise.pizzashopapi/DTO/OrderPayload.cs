namespace exercise.pizzashopapi.DTO
{
    public class OrderPayload
    {
        public OrderPayload(int customerId, int pizzaId, int id)
        {
            CustomerId = customerId;
            PizzaId = pizzaId;
            Id = Id;
        }

        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public int Id { get; set; }
    }
}
