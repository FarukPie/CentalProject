using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concreate
{
    public class BannerManager : IBannerService
    {
        private readonly IBannerDal _bannerdal;

        public BannerManager(IBannerDal bannerdal)
        {
            _bannerdal = bannerdal;
        }

        public void TCreate(Banner entity)
        {
           _bannerdal.Create(entity);
        }

        public void TDelete(int id)
        {
            _bannerdal.Delete(id);  
        }

        public List<Banner> TGetAll()
        {
           return _bannerdal.GetAll();
        }

        public Banner TGetById(int id)
        {
            return _bannerdal.GetById(id);
        }

        public void TUpdate(Banner entity)
        {
            _bannerdal.Update(entity);
        }
    }
}
