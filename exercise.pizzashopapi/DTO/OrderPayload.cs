namespace exercise.pizzashopapi.DTO
{
    public class OrderPayload
    {
        public OrderPayload(string customer, string pizza, decimal price, string status)
        {
            Customer = customer;
            Pizza = pizza;
            Price = price;
            Status = status;
        }

        public string Customer { get; set; }
        public string Pizza { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }
    }
}
