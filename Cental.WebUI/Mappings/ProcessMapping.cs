using AutoMapper;
using Cental.DTOLayer.ProcessDtos;
using EntityProcess = Cental.EntityLayer.Entities.Process;

namespace Cental.WebUI.Mappings
{
    public class ProcessMapping:Profile
    {
        public ProcessMapping() 
        {
            CreateMap<EntityProcess ,CreateProcessDto>().ReverseMap();        
            CreateMap<EntityProcess ,UpdateProcessDto>().ReverseMap();        
            CreateMap<EntityProcess ,ResultProcessDto>().ReverseMap();        
        }
    }
}
