using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.CarDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCarsComponent : ViewComponent
    {
        private readonly ICarService _carservice;
        private readonly IMapper _mapper;
        public _DefaultCarsComponent(ICarService carservice, IMapper mapper)
        {
            _carservice = carservice;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var value = _carservice.TGetAll();
            var car =_mapper.Map<List<ResultCarDto>>(value);
            return View(car);
        }
    }
}
