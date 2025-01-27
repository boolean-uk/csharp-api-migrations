using System.ComponentModel.DataAnnotations.Schema;
using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.Models
{
    public class Product
    {        
        public int Id { get; set; }
        public ProductType ProductType {  get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<Order> Orders { get; set; } = [];
    }
}