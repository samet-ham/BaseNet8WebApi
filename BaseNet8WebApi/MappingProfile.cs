using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Customer Mapping
            CreateMap<Customer, AddCustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, SearchCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
        }
    }
}
