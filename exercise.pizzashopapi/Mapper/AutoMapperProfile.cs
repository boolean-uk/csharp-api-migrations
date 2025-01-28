using AutoMapper;

namespace exercise.pizzashopapi.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Models.Order, DTO.OrderResponse>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Toppings, opt => opt.MapFrom(src => src.Toppings.Select(t => t.Name)));
        CreateMap<Models.Customer, DTO.CustomerResponse>();
        CreateMap<Models.Pizza, DTO.PizzaResponse>();
    }
}