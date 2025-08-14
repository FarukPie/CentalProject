using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProcess = Cental.EntityLayer.Entities.Process;

namespace Cental.BusinessLayer.Abstract
{
    public interface IProcessService: IGenericService<EntityProcess>
    {
    }
}
