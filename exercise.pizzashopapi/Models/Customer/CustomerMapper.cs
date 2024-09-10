using System.Reflection.Metadata.Ecma335;

namespace exercise.pizzashopapi.Models.Customer
{
    public static class CustomerMapper
    {
        public static CustomerDTO MapToDTO(this Customer customer)
        {
            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
            };
        }

        public static List<CustomerDTO> MapListToDTO(this List<Customer> customer)
        {
            return customer.Select(customer=> new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
            }).ToList();
        }
    }
}
