namespace exercise.pizzashopapi.DTOs
{
    public class OrderDTO
    {
        public string Customer {  get; set; }
        public string Pizza { get; set; }
        public DateTime? orderTime { get; set; }
        public string status { get; set; }
    }
}
