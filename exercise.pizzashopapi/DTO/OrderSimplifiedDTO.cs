namespace exercise.pizzashopapi.DTO
{
    public class OrderSimplifiedDTO
    {
        public string productname { get; set; }
        public string productType { get; set; }
        
        public List<OTDTO>producttoppings { get; set; }
    }
}
