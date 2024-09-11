namespace exercise.pizzashopapi.DTOs
{
    public class GetOrderDTO
    {


        public string customerName { get; set; }    
        public string pizzaName { get; set; }

        public DateOnly orderDate { get; set; }

        public string state { get; set; }

        public bool delivered { get; set; }
    }
}
