using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Cental.BusinessLayer.Concreate
{
    public class UserSocialManager(IUserSocialDal _userSocialDal, IMapper _mapper) : IUserSocialService
    {

        public void TCreate(UserSocial entity)
        {
           _userSocialDal.Create(entity);
        }

        public void TDelete(int id)
        {
           _userSocialDal.Delete(id);
        }

        public List<UserSocial> TGetAll()
        {
            return _userSocialDal.GetAll();
        }

        public UserSocial TGetById(int id)
        {
            return _userSocialDal.GetById(id);
        }

        public List<ResultSocialUserDto> TGetSocialsByUserId(int userId)
        {
            var values=_userSocialDal.GetSocialsByUserId(userId);
            return _mapper.Map<List<ResultSocialUserDto>>(values);
        }

        public void TUpdate(UserSocial entity)
        {
           _userSocialDal.Update(entity);
        }
    }
}
