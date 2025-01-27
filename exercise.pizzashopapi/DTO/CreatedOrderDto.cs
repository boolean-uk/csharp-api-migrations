namespace exercise.pizzashopapi.DTO
{
    public class CreatedOrderDto
    {
        public string Customer { get; set; }
        public string Pizza { get; set; }
        public IEnumerable<ToppingDto> Toppings { get; set; }
        public decimal Price { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime OrderedAt { get; set; }
        public int EstimatedDelivery { get; set; }

    } }

