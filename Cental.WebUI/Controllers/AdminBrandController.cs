using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BannerDtos;
using Cental.DTOLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IBrandService _brandservice;
        private readonly IMapper _mapper;

        public AdminBrandController(IBrandService brandservice, IMapper mapper)
        {
            _brandservice = brandservice;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value = _brandservice.TGetAll();
            var brands=_mapper.Map<List<ResultBrandDto>>(value);
            return View(brands);
        }
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBrand(CreateBrandDto model)
        {
            var brand = _mapper.Map<Brand>(model);
            _brandservice.TCreate(brand);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBrand(int id) 
        {
            _brandservice.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var entity = _brandservice.TGetById(id);
            var dto = _mapper.Map<ResultBrandDto>(entity); // Entity → DTO
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBrand(UpdateBrandDto model)
        {
         

            var banner = _mapper.Map<Brand>(model); // DTO → Entity
            _brandservice.TUpdate(banner);

            return RedirectToAction("Index");
        }


    }
}
