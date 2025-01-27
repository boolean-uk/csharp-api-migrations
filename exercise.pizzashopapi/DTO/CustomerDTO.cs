namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
