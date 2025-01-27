namespace exercise.pizzashopapi.Models.DTO
{
    public class MenuItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // e.g., Pizza, Burger, Drink
        public decimal Price { get; set; }
        public int Quantity { get; set; } 
    }
}
