using AutoMapper;
using Cental.DTOLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class UserSocialMapping: Profile
    {
        public UserSocialMapping() 
        {
            CreateMap<UserSocial, ResultSocialUserDto>().ReverseMap();
            CreateMap<UserSocial, CreateSocialUserDto>().ReverseMap();
            CreateMap<UserSocial, UpdateSocialUserDto>().ReverseMap();

        }
    }
}
