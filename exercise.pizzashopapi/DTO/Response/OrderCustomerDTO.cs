using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class OrderCustomerDTO
    {
        public string PizzaName { get; set; }
        public decimal PizzaPrice { get; set; }
    }
}
