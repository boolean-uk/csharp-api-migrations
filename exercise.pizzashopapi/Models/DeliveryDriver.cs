namespace exercise.pizzashopapi.Models;

public record DeliveryDriver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Order> Orders { get; set; }

    public DeliveryDriverShallow ToShallow()
    {
        return new DeliveryDriverShallow { Id = this.Id, Name = this.Name };
    }

    public DeliveryDriverGetDto ToGetDto()
    {
        return new DeliveryDriverGetDto
        {
            Id = this.Id,
            Name = this.Name,
            Orders = this.Orders.Select(o => o.WithoutDriver()),
        };
    }
}
