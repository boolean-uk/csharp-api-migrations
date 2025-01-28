using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;

namespace exercise.pizzashopapi.DTO
{
    public class CreateOrderDTO
    {
        
        public int CustomerId { get; set; }
        public int PizzaID { get; set; }
        public List<CreateToppingDTO> Toppings { get; set; }
    }
}
