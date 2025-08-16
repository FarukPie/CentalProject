using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repostories;
using Cental.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concreate
{
    public class EfCarDal : GenericRepostories<Car>, ICarDal
    {
        public EfCarDal(CentalContext context) : base(context)
        {
        }
        public List<Car> GetCarsWithBrands()
        {
            return _context.Cars.Include(x=>x.Brand).ToList();
        }
    }
}
