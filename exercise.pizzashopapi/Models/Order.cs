﻿using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Column("pizza_id")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        [Column("ordered_at")]
        public DateTime OrderedAt { get; set; } = DateTime.Now;
        [Column("is_delivered")]
        public bool IsDelivered { get; set; } = false;
        [Column("price")]
        public decimal Price { get; set; }

    }
}
