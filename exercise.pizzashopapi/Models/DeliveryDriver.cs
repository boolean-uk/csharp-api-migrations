using exercise.pizzashopapi.DTO;

namespace exercise.pizzashopapi.Models
{
    public class DeliveryDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public DeliveryDriverDTO ToDTO()
        {
            return new DeliveryDriverDTO { Id = this.Id, Name = this.Name };
        }
        public DeliveryDriverBig ToBig()
        {
            return new DeliveryDriverBig
            {
                Id = this.Id,
                Name = this.Name,
                Orders = this.Orders.Select(z => z.NoDriver())
            };
        }
    }
}
