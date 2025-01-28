namespace exercise.pizzashopapi.Models;

public record OrderToppings
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ToppingId { get; set; }
    public Topping Topping { get; set; }

    public OrderToppingsWithoutTopping WithoutTopping()
    {
        return new OrderToppingsWithoutTopping()
        {
            Id = this.Id,
            OrderId = this.OrderId,
            Order = this.Order,
        };
    }

    public OrderToppingsWithoutOrder WithoutOrder()
    {
        return new OrderToppingsWithoutOrder()
        {
            Id = this.Id,
            ToppingId = this.ToppingId,
            Topping = this.Topping,
        };
    }
}
