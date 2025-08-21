using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DTOLayer.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultBannerComponent : ViewComponent
    {
        private readonly IBannerService _banenrservice;
        private readonly IMapper _mapper;
        public _DefaultBannerComponent(IBannerService banenrservice, IMapper mapper)
        {
            _banenrservice = banenrservice;

            _mapper = mapper;
        }


        public IViewComponentResult Invoke()
        {
            var value = _banenrservice.TGetAll();
            var banner = _mapper.Map<List<ResultBannerDto>>(value);

            return View(banner);
        }
    }
}
