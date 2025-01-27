namespace exercise.pizzashopapi.ViewModels
{
    public class CreateOrder
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
