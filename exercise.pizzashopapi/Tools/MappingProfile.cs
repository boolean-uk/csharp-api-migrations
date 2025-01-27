using AutoMapper;
using exercise.pizzashopapi.DTOs;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Pizza, PizzaDTO>();
            CreateMap<Order, OrderDTO>()
                .ForMember(x => x.CustomerName, opt => opt.MapFrom(y => y.Customer.Name))
                .ForMember(z => z.PizzaName, opt => opt.MapFrom(p => p.Pizza.Name));
        }
    }
}
