namespace exercise.pizzashopapi.DTO
{
    public class DeliveryDriverWithOrdersDTO
    {
        public string Name { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
