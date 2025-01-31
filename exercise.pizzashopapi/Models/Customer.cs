using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("customers")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    public Customer() { }

    public Customer(string name)
        {
            Name = name;
        }
    }

    
}
