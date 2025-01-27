namespace exercise.pizzashopapi.DTOs
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public IEnumerable<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
