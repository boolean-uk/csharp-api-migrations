namespace exercise.pizzashopapi.DTO
{
    public record CustomerPost(string Name);
    public record CustomerView(int Id, string Name, IEnumerable<OrderProductToppings> Orders);
    public record CustomerInternal(int Id, string Name);
}
