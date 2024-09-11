using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModels
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CustomerDTO(Customer customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
        }
    }
}
