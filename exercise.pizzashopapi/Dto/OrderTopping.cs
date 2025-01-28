namespace exercise.pizzashopapi.Models;

public record OrderToppingsWithoutOrder
{
    public int Id { get; set; }
    public int ToppingId { get; set; }
    public Topping Topping { get; set; }
}

public record OrderToppingsWithoutTopping
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}
