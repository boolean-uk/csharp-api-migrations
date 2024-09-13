using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTOWithBoth
    {
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
    }
}
