using AutoMapper;
using Cental.DTOLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using System.Runtime.CompilerServices;

namespace Cental.WebUI.Mappings
{
    public class AboutMapping:Profile
    {
        public AboutMapping() 
        { 
            CreateMap<About,ResultListAboutDto>().ReverseMap();        
            CreateMap<About,ResultAboutDto>().ReverseMap();        
            CreateMap<About,CreateAboutDto>().ReverseMap();        
            CreateMap<About,UpdateAboutDto>().ReverseMap();        
        
        }
    }
}
