using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.Enums;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    public class CarsController(ICarService _carService, IBrandService _brandService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult FilterCars()
        {
            var cars = _carService.TGetAll();



            ViewBag.cars = (from x in cars
                            select new SelectListItem
                            {
                                Text = x.Brand.BrandName + " " + x.ModelName,
                                Value = x.Brand.BrandName + " " + x.ModelName,
                            }).ToList();
            ViewBag.gasType = GetEnumValues.GetEnums<GasType>();
            ViewBag.gearType= GetEnumValues.GetEnums<GearType>();
            return PartialView();
        }
    }
}
