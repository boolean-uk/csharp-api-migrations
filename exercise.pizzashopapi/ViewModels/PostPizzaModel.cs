using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.pizzashopapi.ViewModels
{
    public class PostPizzaModel
    {
        public string Name { get; set; }
      
        public decimal Price { get; set; }

    }
}

