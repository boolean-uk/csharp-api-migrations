namespace exercise.pizzashopapi.DTO
{
    public record OrderPost(int ProductId, int CustomerId);
    public record OrderPostAddTopping(int ToppingId);
    public record OrderView(int Id, decimal TotalPrice, CustomerInternal Customer, ProductView Product, IEnumerable<ToppingInternal> Toppings);
    public record OrderProduct(int Id, decimal TotalPrice, ProductView Product);
    public record OrderProductToppings(int Id, decimal TotalPrice, ProductView Product, IEnumerable<ToppingInternal> Toppings);
    public record OrderCustomerProduct(int Id, decimal TotalPrice, CustomerInternal Customer, ProductView Product);
}
