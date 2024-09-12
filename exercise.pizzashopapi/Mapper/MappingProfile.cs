using AutoMapper;
using exercise.pizzashopapi.Models.DTOs;
using exercise.pizzashopapi.Models;
using System.Numerics;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, GetOrderDTO>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
            .ForMember(dest => dest.Pizza, opt => opt.MapFrom(src => src.Pizza.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Pizza.Price));
    }
}