using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int PizzaId { get; set; }

        public CustomerNoListOrderDTO Customer { get; set; }

        public PizzaNoListOrderDTO Pizza { get; set; }

        //public List<OrderTopping> OrderToppings { get; set; } = new List<OrderTopping>();

        [NotMapped]
        public List<string> OrderStatus { get; } = new List<string>
        {
            "Preparing", "Baking", "Quality Check", "Out for Delivery", "Delivered"
        };
    }
}
