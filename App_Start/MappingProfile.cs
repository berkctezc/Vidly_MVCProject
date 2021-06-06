using AutoMapper;
using Vidly_MVCProject.Dtos;
using Vidly_MVCProject.Models;

namespace Vidly_MVCProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}