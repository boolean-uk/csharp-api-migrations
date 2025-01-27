namespace exercise.pizzashopapi.DTO
{
    public class OrderDTODriver
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public DateTime Date = DateTime.Now;
    }
}
