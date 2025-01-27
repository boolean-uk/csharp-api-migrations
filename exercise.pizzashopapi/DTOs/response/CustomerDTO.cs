namespace exercise.pizzashopapi.DTOs.response
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public List<OrderCustomerDTO> Orders { get; set; } = new List<OrderCustomerDTO>();
    }
}
