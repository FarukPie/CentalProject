using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTestimonialComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialservice;
        private readonly IMapper _mapper;

        public _DefaultTestimonialComponent(ITestimonialService testimonialservice, IMapper mapper)
        {
            _testimonialservice = testimonialservice;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var value=_testimonialservice.TGetAll();
            var testimonial=_mapper.Map<List<ResultTestimonialDto>>(value);

            return View(testimonial);
        }
    }
}
