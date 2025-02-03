using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models;

public class OrderToppings : IPizzaShopEntity
{
    public int Id { get;set;}
    public int OrderId {get;set;}
    public int ToppingId {get;set;}
    public DateTime CreatedAt { get;set;}
    public DateTime UpdatedAt { get;set;}
    [NotMapped]
    public virtual Order Order { get;set;}
    [NotMapped]
    public virtual Topping Topping { get;set;}


    public void Update(IPizzaShopEntity entity)
    {
        throw new NotImplementedException();
    }
}
