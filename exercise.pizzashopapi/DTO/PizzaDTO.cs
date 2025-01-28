using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class PizzaDTO
    {
        public PizzaDTO(Pizza p)
        {
            this.Id =      p.Id;
            this.Name =    p.Name;
            this.Price =   p.Price;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
