namespace exercise.pizzashopapi.DTO
{
    public record OrderPost(int ProductId, int CustomerId);
    public record OrderPostAddTopping(int ToppingId);
    public record OrderView(
        int Id, decimal TotalPrice, bool IsDelivered, string PreparationStage, 
        DateTime CreatedAt, DateTime StartedAt, DateTime CompletedAt,
        CustomerInternal Customer, ProductView Product, IEnumerable<ToppingInternal> Toppings
    );
    public record OrderProduct(
        int Id, decimal TotalPrice, bool IsDelivered, string PreparationStage, 
        DateTime CreatedAt, DateTime StartedAt, DateTime CompletedAt,
        ProductView Product
    );
    public record OrderProductToppings(
        int Id, decimal TotalPrice, bool IsDelivered, string PreparationStage, 
        DateTime CreatedAt, DateTime StartedAt, DateTime CompletedAt,
        ProductView Product, IEnumerable<ToppingInternal> Toppings
    );
    public record OrderCustomerProduct(
        int Id, decimal TotalPrice, bool IsDelivered, string PreparationStage, 
        DateTime CreatedAt, DateTime StartedAt, DateTime CompletedAt,
        CustomerInternal Customer, ProductView Product
    );
}
