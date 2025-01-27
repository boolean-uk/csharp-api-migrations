using AutoMapper;
using exercise.pizzashopapi.DTO.Response;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Pizza, opt => opt.MapFrom(src => src.Pizza))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Toppings, opt => opt.MapFrom(src => src.Toppings))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<Customer, CustomerDTO>();

            CreateMap<OrderTopping, OrderToppingDTO>()
                .ForMember(dest => dest.ToppingId, opt => opt.MapFrom(src => src.Topping.Id))
                .ForMember(dest => dest.ToppingName, opt => opt.MapFrom(src => src.Topping.Name));

            CreateMap<OrderProduct, OrderProductDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

        }

    }
}
