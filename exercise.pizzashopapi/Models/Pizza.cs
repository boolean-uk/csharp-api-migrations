using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    
    public class Pizza : IPizzaShopEntity
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [NotMapped]
        public virtual List<Order> Orders { get; set; }

        public void Update(IPizzaShopEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}