using System.ComponentModel.DataAnnotations.Schema;
using exercise.pizzashopapi.DTO;

namespace exercise.pizzashopapi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public CustomerDTO GetSmall()
        {
            return new CustomerDTO()
            {
                Id = this.Id,
                Name = this.Name
            };

        }

        public CustomerDTOBig GetDTO()
        {
            return new CustomerDTOBig()
            {
                Id = this.Id,
                Name = this.Name,
                Orders = this.Orders.Select(o => o.NoCustomer())
            };

        }
    }
}

