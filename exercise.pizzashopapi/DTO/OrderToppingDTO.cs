using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;

namespace exercise.pizzashopapi.DTO
{
    public class OrderToppingDTO
    {
        public OrderToppingDTO(Models.OrderToppings orderTopping) {
            ToppingId = orderTopping.ToppingId;
            Name = orderTopping.Topping.Name;
            Amount = orderTopping.Amount;
        }
        public int ToppingId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
