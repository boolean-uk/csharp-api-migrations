namespace exercise.pizzashopapi.DTOs;

public class CustomerDTO(string name, List<CustomerOrderDTO> list)
{
    public string Name { get; set; } = name;
    public List<CustomerOrderDTO> Orders { get; set; } = list;
}