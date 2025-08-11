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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _branddal;

        public BrandManager(IBrandDal branddal)
        {
            _branddal = branddal;
        }

        public void TCreate(Brand entity)
        {
            _branddal.Create(entity);   
        }

        public void TDelete(int id)
        {
           _branddal.Delete(id);
        }

        public List<Brand> TGetAll()
        {
           return _branddal.GetAll();
        }

        public Brand TGetById(int id)
        {
            return _branddal.GetById(id);   
        }

        public void TUpdate(Brand entity)
        {
           _branddal.Update(entity);
        }
    }
}
