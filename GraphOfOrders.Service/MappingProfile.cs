using AutoMapper;
using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.DTOs;

namespace GraphOfOrders.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
        }
    }
}
