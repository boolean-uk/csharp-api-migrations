namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public OrderCustomerDTO Customer { get; set; }
        public PizzaDTO Pizza { get; set; }
        
    }
}
