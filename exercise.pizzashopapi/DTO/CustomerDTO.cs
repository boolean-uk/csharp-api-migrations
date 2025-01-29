namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrderSimplifiedDTO> Orders { get; set; } = new List<OrderSimplifiedDTO>();
    }
}
