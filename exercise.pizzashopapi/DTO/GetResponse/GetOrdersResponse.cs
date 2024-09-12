namespace exercise.pizzashopapi.DTO.GetResponse
{
    public class GetOrdersResponse
    { 
        public ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
