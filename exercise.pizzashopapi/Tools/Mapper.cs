using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Tools
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //CreateMap<Order, OrderDTO>();
            //CreateMap<OrderDTO, Order>();
            //CreateMap<OrderTopping, OrderToppingDTO>();
            //CreateMap<OrderToppingDTO, OrderTopping>();
            //CreateMap<Customer, CustomerDTO>();
            //CreateMap<CustomerDTO, Customer>();
            //CreateMap<Toppings, ToppingsDTO>();
            //CreateMap<ToppingsDTO, Toppings>();
            CreateMap<Pizza, PizzaDTO>();
            CreateMap<Customer, CustomerNoListOrderDTO>().ReverseMap();
            CreateMap<Pizza, PizzaNoListOrderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Pizza, opt => opt.MapFrom(src => src.Pizza))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.PizzaId, opt => opt.MapFrom(src => src.PizzaId))
                .ForMember(dest => dest.OrderStatus, opt => opt.Ignore());


            //CreateMap<PizzaDTO, Pizza>();
        }

    }
}
