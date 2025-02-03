using System;
using AutoMapper;
using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Utility;

public class Mappers : Profile
{

    public Mappers()
    {
        CreateMap<Pizza, PizzaDTO>();
        CreateMap<Customer, CustomerDTO>();
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderToppings, OrderToppingDTO>();
        CreateMap<Topping, ToppingDTO>();
        
    }


}
