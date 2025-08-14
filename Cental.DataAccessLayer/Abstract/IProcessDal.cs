using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProcess = Cental.EntityLayer.Entities.Process;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IProcessDal:IGenericDal<EntityProcess>
    {
    }
}
