namespace exercise.pizzashopapi.DTO
{
    public class DTOOrder
    {
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }

        public DateTime StartTime { get; set; }

        public bool IsDelivered { get; set; } 
    }
}
