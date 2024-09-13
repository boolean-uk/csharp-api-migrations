namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTOWithOrders
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OrderDTO> OrderDTO {  get; set; } = new List<OrderDTO>();
    }
}
