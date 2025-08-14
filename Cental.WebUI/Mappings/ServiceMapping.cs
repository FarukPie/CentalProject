using AutoMapper;
using Cental.DTOLayer.ServiceDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ServiceMapping:Profile
    {
        public ServiceMapping() 
        {
        CreateMap<Service, CreateServiceDto>().ReverseMap();
        CreateMap<Service, UpdateServiceDto>().ReverseMap();
        CreateMap<Service, ResultServiceDto>().ReverseMap();
        }
    }
}
