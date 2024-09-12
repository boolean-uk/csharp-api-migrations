namespace exercise.pizzashopapi.DTOs.Order
{
    public class GetOrdersResponse
    {
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
