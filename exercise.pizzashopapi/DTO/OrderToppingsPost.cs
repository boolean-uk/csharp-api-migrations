using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class OrderToppingsPost
    {
        public int OrderId { get; set; }
        public int ToppingId { get; set; }
    }
}
