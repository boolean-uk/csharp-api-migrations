namespace exercise.pizzashopapi.Models;

public class CustomerGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<OrderWithoutCustomer> Orders { get; set; }
}

public class CustomerPostDto
{
    public string Name { get; set; }
}

public class CustomerShallow
{
    public int Id { get; set; }
    public string Name { get; set; }
}
