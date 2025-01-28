namespace exercise.pizzashopapi.Models;

public record DeliveryDriverPostDto
{
    public string Name { get; set; }
}

public record DeliveryDriverGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<OrderWithoutDriver> Orders { get; set; }
}

public record DeliveryDriverShallow
{
    public int Id { get; set; }
    public string Name { get; set; }
}
