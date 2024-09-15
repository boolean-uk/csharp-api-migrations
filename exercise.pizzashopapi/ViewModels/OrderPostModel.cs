namespace exercise.pizzashopapi.ViewModels
{
    public class OrderPostModel
    {
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
