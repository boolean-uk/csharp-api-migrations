namespace exercise.pizzashopapi.Models;

public record Topping
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
