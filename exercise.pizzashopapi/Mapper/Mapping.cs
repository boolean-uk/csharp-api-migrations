using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
namespace exercise.pizzashopapi.Mapper
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<Pizza, PizzaDTO>();
            CreateMap<Pizza, PizzaListDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<Customer, CustomerDTO>()
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));

            CreateMap<Order, CustomerOrderDTO>()
                .ForMember(dest => dest.Pizza, opt => opt.MapFrom(src => src.Pizza))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Order, OrderCustomerDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer.Name));

            CreateMap<Order, PizzaDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Pizza));

            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Pizza, opt => opt.MapFrom(src => src.Pizza));

            CreateMap<Customer, OrderCustomerDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
            CreateMap<Pizza, PizzaDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

        }
    }
}
