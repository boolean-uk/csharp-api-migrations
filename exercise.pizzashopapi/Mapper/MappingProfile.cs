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

        CreateMap<CreateOrderDTO, Order>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Customer, opt => opt.Ignore())
            .ForMember(dest => dest.Pizza, opt => opt.Ignore());

        CreateMap<CreatePizzaDTO, Pizza>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Customer, GetCustomerDTO>()
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));

        CreateMap<CreateCustomerDTO, Customer>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Order, opt => opt.Ignore());


    }
}