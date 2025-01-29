namespace exercise.pizzashopapi.Models
{
    public class Toppings
    {
        public int id { get; set; }
        public string name {  get; set; }
        public int cost {get;set;}
        public List<OrderToppings> OrderToppings { get; set; }
    }
}
