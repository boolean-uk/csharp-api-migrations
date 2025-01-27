namespace exercise.pizzashopapi.DTOs
{
    public class OrderDTO
    {
        public int CustomerId { get; set; } 
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public string CustomerName { get; set; }
    }
}
