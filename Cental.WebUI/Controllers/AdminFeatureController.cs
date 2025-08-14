using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BannerDtos;
using Cental.DTOLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminFeatureController : Controller
    {
        private readonly IFeatureService _featureservice;

        public AdminFeatureController(IFeatureService featureservice, IMapper mapper)
        {
            _featureservice = featureservice;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        public IActionResult Index()
        {
            var value = _featureservice.TGetAll();
            var feature = _mapper.Map<List<ResultFeatureDto>>(value);

            return View(feature);
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto feature)
        {
            var value=_mapper.Map<Feature>(feature);
            _featureservice.TCreate(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var entity = _featureservice.TGetById(id);
            var dto = _mapper.Map<ResultFeatureDto>(entity); // Entity → DTO
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFeature(UpdateFeatureDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var banner = _mapper.Map<Feature>(model); // DTO → Entity
            _featureservice.TUpdate(banner);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteFeature(int id)
        {
            _featureservice.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
