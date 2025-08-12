using AutoMapper;
using Cental.BusinessLayer.Abstract;
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
            return View(brand);
        }

    }
}
