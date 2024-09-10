using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models.Order
{
    public class Order
    {
        int Id { get; set; }
        int CustomerId { get; set; }
        int PizzaId { get; set; }


    }
}
