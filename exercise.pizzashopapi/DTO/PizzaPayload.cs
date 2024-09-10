namespace exercise.pizzashopapi.DTO
{
    public class PizzaPayload
    {
        public PizzaPayload(string name, decimal price, int id)
        {
            Name = name;
            Price = price;
            Id = id;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
    }
}
