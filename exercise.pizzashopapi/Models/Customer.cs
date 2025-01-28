using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Order> Orders { get; set; }

    public CustomerShallow ToShallow()
    {
        return new CustomerShallow() { Name = this.Name, Id = this.Id };
    }

    public CustomerGetDto ToGetDto()
    {
        return new CustomerGetDto()
        {
            Id = this.Id,
            Name = this.Name,
            Orders = this.Orders.Select(o => o.WithoutCustomer()),
        };
    }
}
