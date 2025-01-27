using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Topping> Toppings { get; set; } = [];

        [NotMapped]
        public decimal TotalPrice => Product.Price + Toppings.Sum(t => t.Price);
    }
}
