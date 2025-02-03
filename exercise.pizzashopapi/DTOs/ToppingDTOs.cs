using System;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace exercise.pizzashopapi.DTOs;

public class ToppingDTO
{

    public string Name { get; set; }
    public decimal Price {get;set;}
}
