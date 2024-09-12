using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.DTOs
{
    public class OrderPostModel
    {

        [Required(ErrorMessage = "CustomerId is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "PizzaId is required")]
        public int PizzaId { get; set; }
        
    }
}
