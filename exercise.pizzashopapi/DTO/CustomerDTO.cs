using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CustomerDTO(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
