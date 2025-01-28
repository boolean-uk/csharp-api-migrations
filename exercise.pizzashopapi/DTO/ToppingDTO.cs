using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class ToppingDTO
    {
        public ToppingDTO(Topping o)
        {
            Id = o.Id;
            Name = o.Name;
            Price = o.Price;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
    }
}
