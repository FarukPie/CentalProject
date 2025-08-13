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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featuredal;

        public FeatureManager(IFeatureDal featuredal)
        {
            _featuredal = featuredal;
        }
        public void TCreate(Feature entity)
        {
            _featuredal.Create(entity);
        }

        public void TDelete(int id)
        {
            _featuredal.Delete(id);
        }

        public List<Feature> TGetAll()
        {
            return _featuredal.GetAll();
        }

        public Feature TGetById(int id)
        {
            return _featuredal.GetById(id);
        }

        public void TUpdate(Feature entity)
        {
            _featuredal.Update(entity);
        }
    }
}
