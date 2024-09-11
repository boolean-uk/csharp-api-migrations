using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
        public string Status { get; set; }
    }
}
