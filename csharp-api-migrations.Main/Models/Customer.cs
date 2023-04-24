using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static csharp_api_migrations.Main.Enums;

namespace csharp_api_migrations.Main.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public ICollection<Order> Orders { get; set; } = null;
    }
}
