using AutoMapper;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.ProcessDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultProcessComponent : ViewComponent
    {
        private readonly IProcessDal _processdal;
        private readonly IMapper _mapper;
        public _DefaultProcessComponent(IProcessDal processdal, IMapper mapper)
        {
            _processdal = processdal;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var value = _processdal.GetAll();
            var prcs=_mapper.Map<List<ResultProcessDto>>(value);
            return View(prcs);
        }
    }
}
