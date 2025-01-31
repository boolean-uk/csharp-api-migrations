namespace exercise.pizzashopapi.DTOs.response
{
    public class OrderDTO
    {
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }
        public string PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
        public string CustomerName { get; set; }
    }
}
