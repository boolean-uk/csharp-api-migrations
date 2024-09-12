namespace exercise.pizzashopapi.DTO.GetResponse
{
    public class GetCustomerResponse
    {
        public ICollection<CustomerDTO> Customers { get; set; } = new List<CustomerDTO>();
    }
}
