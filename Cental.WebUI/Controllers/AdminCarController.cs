using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BrandDtos;
using Cental.DTOLayer.CarDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public AdminCarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value = _carService.TGetCarsWithBrands();
            var car=_mapper.Map<List<ResultCarDto>>(value);
            return View(car);
        }
        [HttpGet]
        public IActionResult CreateCar() 
        {
        return View();
        }
        [HttpPost]  
        public IActionResult CreateCar(CreateCarDto dto)
        {
            var car = _mapper.Map<Car>(dto);
            _carService.TCreate(car);
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult UpdateCar(int id)
        {
            var entity = _carService.TGetById(id);
            var dto = _mapper.Map<ResultCarDto>(entity); // Entity → DTO
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCar(UpdateCarDto model)
        {


            var banner = _mapper.Map<Car>(model); // DTO → Entity
           _carService.TUpdate(banner);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteCar(int id)
        {
            _carService.TDelete(id);
            return RedirectToAction("Index");
        }

    }
}
