using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultAboutComponent: ViewComponent 
    {
        private readonly IAboutService _aboutservice;
        private readonly IMapper _mapper;

        public _DefaultAboutComponent(IAboutService aboutservice, IMapper mapper)
        {
            _aboutservice = aboutservice;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var value = _aboutservice.TGetAll();
            var about=_mapper.Map<List<ResultListAboutDto>>(value);
            return View(about);
        }
    }
}
