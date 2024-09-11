﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{

    [Table("Pizza")]
    public class Pizza
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
    }
}