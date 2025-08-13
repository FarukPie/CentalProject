using AutoMapper;
using Cental.DTOLayer.FeatureDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class FeatureMapping: Profile
    {
        public FeatureMapping() 
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        
        
        }
    }
}
