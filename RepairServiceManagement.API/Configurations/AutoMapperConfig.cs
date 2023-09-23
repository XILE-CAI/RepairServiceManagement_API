using AutoMapper;
using RepairServiceManagement.API.Data;
using RepairServiceManagement.API.Models.Customer;
using RepairServiceManagement.API.Models.RepairRequest;

namespace RepairServiceManagement.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //RepairRequest
            CreateMap<RepairRequest, CreateRepairRequestDto>().ReverseMap();
            CreateMap<RepairRequest, UpdateRepairRequestDto>().ReverseMap();
            CreateMap<RepairRequest, GetRepairRequestsDto>().ReverseMap();
            CreateMap<RepairRequest, GetRepairRequestDetailDto>().ReverseMap();

            //Customer
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetCustomersDto>().ReverseMap();
            CreateMap<Customer, GetCustomerDetailDto>().ReverseMap();
        }
    }
}
