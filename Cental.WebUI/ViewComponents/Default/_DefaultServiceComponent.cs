using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultServiceComponent : ViewComponent
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public _DefaultServiceComponent(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var value = _serviceService.TGetAll();
            var service=_mapper.Map<List<ResultServiceDto>>(value);
          
            return View(service);
        }
    }
}
