using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repostories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProcess = Cental.EntityLayer.Entities.Process;

namespace Cental.DataAccessLayer.Concreate
{
    public class EfProcessDal : GenericRepostories<EntityProcess>, IProcessDal
    {
        public EfProcessDal(CentalContext context) : base(context)
        {
        }
    }
}
