using System;
using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
namespace exercise.pizzashopapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pizza, PizzaDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<OrderToppings, OrderToppingsDTO>();
            CreateMap<Toppings, ToppingsDTO>();
        }
    }
}
