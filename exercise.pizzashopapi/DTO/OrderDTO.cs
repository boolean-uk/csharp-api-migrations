using exercise.pizzashopapi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public string Customer { get; set; }
        public string Pizza { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
