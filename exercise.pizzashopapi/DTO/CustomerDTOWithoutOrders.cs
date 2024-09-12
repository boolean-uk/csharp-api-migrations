using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTOWithoutOrders
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
