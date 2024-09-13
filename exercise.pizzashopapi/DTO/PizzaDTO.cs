namespace exercise.pizzashopapi.DTO
{
    public record CreatePizzaDTO(string PizzaName, decimal Price)
    {

    }
    public record GetPizzaDTO(string PizzaName, decimal Price)
    {

    }
}
