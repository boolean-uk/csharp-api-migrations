using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTOWithOrders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
