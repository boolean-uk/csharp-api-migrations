namespace exercise.pizzashopapi.DTO
{
    public class PizzaPayload
    {
        public PizzaPayload(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
