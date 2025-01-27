using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTOS
{
    public class OrderDTO
    {
        public string CustomerName { get; set; }
        public string PizzaName { get; set; }
        public decimal Price { get; set; }

    }
}
