namespace exercise.pizzashopapi.DTO
{
    public class OrderPayload
    {
        public OrderPayload(string customer, string pizza, decimal price)
        {
            Customer = customer;
            Pizza = pizza;
            Price = price;
        }

        public string Customer { get; set; }
        public string Pizza { get; set; }

        public decimal Price { get; set; }
    }
}
