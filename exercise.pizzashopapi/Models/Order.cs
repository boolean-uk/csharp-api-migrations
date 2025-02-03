using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order : IPizzaShopEntity
    {
        public int Id {get;set;}
        public int CustomerId {get;set;}
        public int PizzaId {get;set;}
        public int OrderToppingsId {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        [NotMapped]
        public virtual Customer Customer {get;set;}
        [NotMapped]
        public virtual Pizza Pizza {get;set;}
        [NotMapped] 
        public virtual List<OrderToppings> OrderToppings {get;set;}

        public void Update(IPizzaShopEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
