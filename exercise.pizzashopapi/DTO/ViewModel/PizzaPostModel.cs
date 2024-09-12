using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO.ViewModel
{
    public class PizzaPostModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
