namespace exercise.pizzashopapi.DTO
{
    public class OrderPost
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public int? DriverId { get; set; }
    }
}
