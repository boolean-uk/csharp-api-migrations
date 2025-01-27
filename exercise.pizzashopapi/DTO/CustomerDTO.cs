namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public List<CustomerOrderDTO> Orders { get; set; } = new List<CustomerOrderDTO>();
    }
}
