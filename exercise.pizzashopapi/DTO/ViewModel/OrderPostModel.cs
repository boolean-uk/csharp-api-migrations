using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.DTO.ViewModel
{
    public class OrderPostModel
    {
        public int PizzaID { get; set; }
        public int CustomerID { get; set; }
    }
}
