using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string> Orders { get; set; } = new List<String>();
        public PizzaDTO(Pizza pizza) 
        {
            Id = pizza.Id;  
            Name = pizza.Name;
            Price = pizza.Price;
            pizza.Orders.ForEach(x => Orders.Add($"{x.pizzas} {x.customer}"));

        }
    }
}
