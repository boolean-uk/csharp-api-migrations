using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class DeliveryDriverPost
    {
        public string Name { get; set; }
    }
    public class DeliveryDriverDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DeliveryDriverBig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<OrderWithoutDriver> Orders { get; set; }
    }
}
