using System;
using exercise.pizzashopapi.Enums;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO;

public class OrderDTO
{
        public CustomerDTO Customer { get; set; }
        public PizzaDTO Pizza { get; set; }
        public IEnumerable<ToppingDTO> Toppings { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStage OrderStage { get; set; } 
}
