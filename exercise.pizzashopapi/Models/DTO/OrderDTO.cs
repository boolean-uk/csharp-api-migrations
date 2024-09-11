namespace exercise.pizzashopapi.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Stage { get; set; }
        public DateTime Pickup {  get; set; }
        public CustomerDTO Customer { get; set; }
        public PizzaDTO Pizza { get; set; }
    }
}