using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("pizzas")]

    public class Pizza
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public Pizza() { }
        public Pizza(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}