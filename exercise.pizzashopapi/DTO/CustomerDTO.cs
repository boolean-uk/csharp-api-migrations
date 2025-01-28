using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Orders { get; set; } = new List<string>();

        public CustomerDTO(Customer customer) 
        {
            Id = customer.Id;
            Name = customer.Name;
            customer.Orders.ForEach(x => Orders.Add($"{x.pizza}"));
        }
    }
}
