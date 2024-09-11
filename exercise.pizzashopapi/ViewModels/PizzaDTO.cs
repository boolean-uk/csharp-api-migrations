using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModels
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public PizzaDTO(Pizza pizza)
        {
            this.Id = pizza.Id;
            this.Name = pizza.Name;
            this.Price = $"${pizza.Price}";
        }

    }
}
