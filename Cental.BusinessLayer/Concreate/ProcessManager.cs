using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProcess = Cental.EntityLayer.Entities.Process;

namespace Cental.BusinessLayer.Concreate
{
    public class ProcessManager : IProcessService
    {
        private readonly IProcessDal _processdal;

        public ProcessManager(IProcessDal processdal)
        {
            _processdal = processdal;
        }

        public void TCreate(EntityProcess entity)
        {
            _processdal.Create(entity);
        }

        public void TDelete(int id)
        {
            _processdal.Delete(id);
        }

        public List<EntityProcess> TGetAll()
        {
            return _processdal.GetAll();
        }

        public EntityProcess TGetById(int id)
        {
            return _processdal.GetById(id);
        }

        public void TUpdate(EntityProcess entity)
        {
            _processdal.Update(entity);
        }
    }
}
