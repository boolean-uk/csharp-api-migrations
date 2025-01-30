using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CustomerDTOBig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<OrderWithoutCustomer> Orders { get; set; }
    }
}
