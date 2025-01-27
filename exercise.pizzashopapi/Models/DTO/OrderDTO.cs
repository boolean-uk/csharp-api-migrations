namespace exercise.pizzashopapi.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
        public int? DeliveryDriverId { get; set; }
        public string DeliveryDriverName { get; set; }
        public DateTime OrderDate { get; set; }

        public List<MenuItemDTO> MenuItems { get; set; } = new List<MenuItemDTO>();
    }
}
