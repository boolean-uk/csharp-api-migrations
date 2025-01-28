namespace exercise.pizzashopapi.Models;

public record OrderGetDto
{
    public int Id { get; set; }

    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }

    public IEnumerable<OrderToppingsWithoutOrder> OrderToppings { get; set; }

    public int CustomerId { get; set; }
    public CustomerShallow Customer { get; set; }

    public int DeliveryDriverId { get; set; }
    public DeliveryDriverShallow DeliveryDriver { get; set; }
}

public record OrderPostDto
{
    public int PizzaId { get; set; }
    public IEnumerable<int> ToppingIds { get; set; }
    public int CustomerId { get; set; }
    public int DeliveryDriverId { get; set; }
}

public record OrderShallow
{
    public int Id { get; set; }

    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }

    public IEnumerable<OrderToppingsWithoutOrder> OrderToppings { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int DeliveryDriverId { get; set; }
    public DeliveryDriver DeliveryDriver { get; set; }
}

public record OrderWithoutCustomer
{
    public int Id { get; set; }

    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }

    public IEnumerable<OrderToppingsWithoutOrder> OrderToppings { get; set; }

    public int DeliveryDriverId { get; set; }
    public DeliveryDriverShallow DeliveryDriver { get; set; }
}

public record OrderWithoutDriver
{
    public int Id { get; set; }

    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }

    public IEnumerable<OrderToppingsWithoutOrder> OrderToppings { get; set; }

    public int CustomerId { get; set; }
    public CustomerShallow Customer { get; set; }
}
