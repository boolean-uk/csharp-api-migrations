using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.ViewModels
{
    public class PostOrderModel
    {
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
    }
}
