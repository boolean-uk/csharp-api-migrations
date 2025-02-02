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

        public string OrderStatus { get; set; }
    }
}
