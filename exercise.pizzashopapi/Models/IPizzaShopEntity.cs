using System;

namespace exercise.pizzashopapi.Models;

public interface IPizzaShopEntity
{
    public int Id {get;set;}
    public DateTime CreatedAt {get;set;}
    public DateTime UpdatedAt {get;set;}

    public void Update(IPizzaShopEntity entity);
}
