using System.Collections.Generic;
using System.Xml.Linq;

namespace exercise.pizzashopapi.DTOS
{
    public class CustomerDTO
    {

        public int CustomerId { get; set; } 
        public string Name { get; set; }
        public List<OrderDTO> Orders { get; set;} = new List<OrderDTO>();
    }
}

