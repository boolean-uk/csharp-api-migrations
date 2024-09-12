namespace exercise.pizzashopapi.DTO
{
    public class SingleCustomerDTOWithOrders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CustomerOrdersDTO> Orders { get; set; } = new List<CustomerOrdersDTO>();
    }
}
