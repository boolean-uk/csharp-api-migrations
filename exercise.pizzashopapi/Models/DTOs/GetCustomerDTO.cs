namespace exercise.pizzashopapi.Models.DTOs
{
    public class GetCustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GetOrderDTO Order { get; set; }
    }
}
