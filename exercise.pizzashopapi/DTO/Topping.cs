namespace exercise.pizzashopapi.DTO
{
    public record ToppingView(int Id, string Name, decimal Price, IEnumerable<OrderCustomerProduct> Orders);
    public record ToppingInternal(int Id, string Name, decimal Price);
}
