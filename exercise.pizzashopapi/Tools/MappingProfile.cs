using AutoMapper;
using exercise.pizzashopapi.DTOs.response;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));
            CreateMap<Pizza, PizzaDTO>();
            CreateMap<Order, OrderCustomerDTO>();
            CreateMap<Order, OrderPizzaDTO>();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.PizzaName, opt => opt.MapFrom(src => src.Pizza.Name))
                .ForMember(dest => dest.PizzaPrice, opt => opt.MapFrom(src => src.Pizza.Price))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));

        }
    }
}
