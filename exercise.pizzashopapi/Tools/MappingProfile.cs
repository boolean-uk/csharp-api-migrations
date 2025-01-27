using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductView>()
                .ForMember(p => p.ProductType, opt => opt.MapFrom(src => src.ProductType.ToString()));

            CreateMap<Order, OrderView>();
            CreateMap<Order, OrderCustomerProduct>();
            CreateMap<Order, OrderProduct>();
            CreateMap<Order, OrderProductToppings>();

            CreateMap<Customer, CustomerView>();
            CreateMap<Customer, CustomerInternal>();

            CreateMap<Topping, ToppingView>();
            CreateMap<Topping, ToppingInternal>();
        }
    }
}
