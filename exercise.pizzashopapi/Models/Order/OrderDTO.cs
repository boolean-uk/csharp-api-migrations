namespace exercise.pizzashopapi.Models.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public DateTime orderTime { get; set; }
        public bool isDelivered { get; set; }
    }
}
