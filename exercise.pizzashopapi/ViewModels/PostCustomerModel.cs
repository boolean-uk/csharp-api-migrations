using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.pizzashopapi.ViewModels
{
    public class PostCustomerModel
    {
        [Required(ErrorMessage = "Customer name is required")]
        public string Name { get; set; }

    }

}
