using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.BrandDtos
{
    public class CreateBrandDto
    {
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }

    }
}
