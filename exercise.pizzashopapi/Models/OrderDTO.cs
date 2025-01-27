namespace exercise.pizzashopapi.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int? DriverId { get; set; }
        public string? DriverName { get; set; }

    }
}
