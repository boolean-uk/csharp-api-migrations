using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } //Vraagteken betekent dat het niet nullable is, voeg het vraagteken toe na string zodat het non-nullable is
    }
}
