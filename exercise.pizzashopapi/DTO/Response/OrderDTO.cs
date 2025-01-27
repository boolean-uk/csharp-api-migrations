using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.DTO.Response
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Pizza Pizza { get; set; }
        public CustomerDTO Customer { get; set; }
        public List<OrderToppingDTO> Toppings { get; set; } = new();
        public List<OrderProductDTO> Products { get; set; } = new();
    }
}
