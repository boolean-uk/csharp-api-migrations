using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.DTOs
{
    public class ResponsePizzaDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class PostPizzaDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
