using System.ComponentModel.DataAnnotations.Schema;
using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsDelivered { get; set; } = false;
        public PreparationStage PreparationStage { get; set; } = PreparationStage.Waiting;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? StartedAt { get; set; } = null;
        public DateTime? CompletedAt { get; set; } = null;

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Topping> Toppings { get; set; } = [];

        [NotMapped]
        public decimal TotalPrice => Product.Price + Toppings.Sum(t => t.Price);
    }
}
