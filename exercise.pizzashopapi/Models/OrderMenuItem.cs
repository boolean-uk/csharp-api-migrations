using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.Models
{
    public class OrderMenuItem
    {
        [Key] // Primary key part 1
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Key] // Primary key part 2
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; } // Allows multiple of the same item
    }
}
