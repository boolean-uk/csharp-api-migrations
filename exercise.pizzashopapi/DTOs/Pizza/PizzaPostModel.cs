using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.DTOs.Pizza
{
    public class PizzaPostModel
    {
        [Required(ErrorMessage = "Pizza name is required")]
        public string PizzaName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
    }
}
