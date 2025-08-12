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
            var thisyear=DateTime.Now.Year;
            CreateMap<About,ResultListAboutDto>().ForMember(x=>x.ExperienceYear,o=>o.MapFrom(src=>thisyear-src.StartYear));        
            CreateMap<About,ResultAboutDto>().ReverseMap();        
            CreateMap<About,CreateAboutDto>().ReverseMap();        
            CreateMap<About,UpdateAboutDto>().ReverseMap();        
        
        }
    }
}
