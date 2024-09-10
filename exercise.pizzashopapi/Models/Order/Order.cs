using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PizzaId { get; set; }


    }
}
