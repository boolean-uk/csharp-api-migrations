using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int OrderId { get; set; }

        public List<Order> Orders { get; set; }
    }
}
