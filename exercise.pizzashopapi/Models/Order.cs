using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
      
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer customer { get; set; }

        public int PizzaId { get; set; }

        public Pizza pizza { get; set; }

        public DateOnly OrderDate { get; set; }

        public string orderState { get; set; }

        public bool delivered { get; set; }

    }
}
