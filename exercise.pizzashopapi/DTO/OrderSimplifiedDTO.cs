namespace exercise.pizzashopapi.DTO
{
    public class OrderSimplifiedDTO
    {
        public string pizzaname { get; set; }
        
        public List<OTDTO>pizzatoppings { get; set; }
    }
}
