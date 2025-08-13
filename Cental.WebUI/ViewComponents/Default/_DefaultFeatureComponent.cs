using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.FeatureDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFeatureComponent:ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _DefaultFeatureComponent(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        public IViewComponentResult Invoke()
        {
            var value = _featureService.TGetAll();
            var feature=_mapper.Map<List<ResultFeatureDto>>(value);
            return View(feature);
        }
    }
}
