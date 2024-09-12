using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.DTOs.Customer
{
    public class CustomerPostModel
    {
        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }
    }
}
