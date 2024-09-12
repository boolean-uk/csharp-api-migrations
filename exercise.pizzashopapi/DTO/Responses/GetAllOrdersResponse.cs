namespace exercise.pizzashopapi.DTO.Responses
{
    public class GetAllOrdersResponse
    {
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
