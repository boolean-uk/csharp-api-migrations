using System;
using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.DTO;

public class OrderStatusPut
{
    public int OrderId { get; set; }
    public OrderStage OrderStage { get; set; }
}
