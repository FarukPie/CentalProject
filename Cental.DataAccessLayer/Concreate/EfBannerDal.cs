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
    public class EfBannerDal : GenericRepostories<Banner>, IBannerDal
    {
        public EfBannerDal(CentalContext context) : base(context)
        {
        }
    }
}
