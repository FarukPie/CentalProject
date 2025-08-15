using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BrandDtos;
using Cental.DTOLayer.ServiceDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IServiceService _serviceservice;
        private readonly IMapper _mapper;

        public AdminServiceController(IServiceService serviceservice, IMapper mapper)
        {
            _serviceservice = serviceservice;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value=_serviceservice.TGetAll();
            var service=_mapper.Map<List<ResultServiceDto>>(value);
            return View(service);
        }
        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDto model)
        {
            var value = _mapper.Map<Service>(model);
            _serviceservice.TCreate(value);
            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var entity = _serviceservice.TGetById(id);
            var dto = _mapper.Map<ResultServiceDto>(entity); // Entity → DTO
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateService(UpdateServiceDto model)
        {


            var banner = _mapper.Map<Service>(model); // DTO → Entity
            _serviceservice.TUpdate(banner);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            _serviceservice.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
