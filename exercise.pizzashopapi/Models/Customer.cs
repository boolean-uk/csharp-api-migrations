using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Customer : IPizzaShopEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [NotMapped]
        public virtual List<Order> Orders { get; set; }
        [NotMapped]
        public virtual List<OrderToppings> OrderToppings { get; set; }


        public void Update(IPizzaShopEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
