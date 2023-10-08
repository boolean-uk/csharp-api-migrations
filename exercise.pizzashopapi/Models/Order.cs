using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
