using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
