using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.Models
{
    public class OrderProduct
    {
        [Key]
        public int OrderId { get; set; }

        [Key]
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
