using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models.Pizza
{

    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}