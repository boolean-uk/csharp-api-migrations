namespace exercise.pizzashopapi.DTO
{
    public class OrderDto
    {
        public string Customer { get; set; }
        public string Pizza { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderedAt { get; set; }
        public bool IsDelivered { get; set; }
    }
}
