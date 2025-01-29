using System;
using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Tools;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDTO>();
        CreateMap<Order, OrderDTO>();
        CreateMap<Pizza, PizzaDTO>();
        CreateMap<Topping, ToppingDTO>();
        CreateMap<CustomerPost, Customer>();
        CreateMap<OrderPost, Order>();
        CreateMap<PizzaPost, Pizza>();
        CreateMap<ToppingPost, Topping>();
        CreateMap<Order, OrderStatusDTO>();
        CreateMap<ToppingOrderPost, OrderToppings>();
        CreateMap<OrderStatusPut, Order>();
    }
}
