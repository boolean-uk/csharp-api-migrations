using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class CustomerNoListOrderDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
