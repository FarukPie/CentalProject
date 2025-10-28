using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repostories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concreate
{
    public class EfUserSocialDal : GenericRepostories<UserSocial>, IUserSocialDal
    {
        public EfUserSocialDal(CentalContext context) : base(context)
        {

        }

        public List<UserSocial> GetSocialsByUserId(int userId)
        {
            return _context.UserSocials.Where(x=>x.UserId==userId).ToList();
        }
    }
}
