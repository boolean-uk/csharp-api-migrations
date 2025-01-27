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

            CreateMap<Order, OrderView>()
                .ForMember(p => p.PreparationStage, opt => opt.MapFrom(src => src.PreparationStage.ToString()));
            CreateMap<Order, OrderCustomerProduct>()
                .ForMember(p => p.PreparationStage, opt => opt.MapFrom(src => src.PreparationStage.ToString()));
            CreateMap<Order, OrderProduct>()
                .ForMember(p => p.PreparationStage, opt => opt.MapFrom(src => src.PreparationStage.ToString()));
            CreateMap<Order, OrderProductToppings>()
                .ForMember(p => p.PreparationStage, opt => opt.MapFrom(src => src.PreparationStage.ToString()));

            CreateMap<Customer, CustomerView>();
            CreateMap<Customer, CustomerInternal>();

            CreateMap<Topping, ToppingView>();
            CreateMap<Topping, ToppingInternal>();
        }
    }
}
