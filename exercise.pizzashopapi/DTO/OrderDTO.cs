using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public List<ToppingsDTO> Toppings { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
