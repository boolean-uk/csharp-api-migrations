namespace exercise.pizzashopapi.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; } // e.g., Pizza, Burger, Drink
    }
}
