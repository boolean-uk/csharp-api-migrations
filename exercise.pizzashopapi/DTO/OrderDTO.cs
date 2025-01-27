using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        
        public int Id { get; set; }
        public string customer { get; set; }
        public List<string> pizzas { get; set; }
    }
}
