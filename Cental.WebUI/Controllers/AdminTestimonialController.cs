using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BrandDtos;
using Cental.DTOLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public AdminTestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value=_testimonialService.TGetAll();
            var testimonial = _mapper.Map<List<ResultTestimonialDto>>(value);
            return View(testimonial);
        }
        [HttpGet]
        public IActionResult CreateTestimonial() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto model)
        {
            var dto=_mapper.Map<Testimonial>(model);
            _testimonialService.TCreate(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var entity = _testimonialService.TGetById(id);
            var dto = _mapper.Map<ResultTestimonialDto>(entity); // Entity → DTO
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto model)
        {


            var banner = _mapper.Map<Testimonial>(model); // DTO → Entity
            _testimonialService.TUpdate(banner);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
