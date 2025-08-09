using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;

        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value = _bannerService.TGetAll();
            var banners = _mapper.Map<List<ResultBannerDto>>(value);
            return View(banners);
        }
        public IActionResult CreateBanner()
        {
            return View();  
        }
        public IActionResult CreateBanner(CreateBannerDto model)
        {
            var banner=_mapper.Map<Banner>(model);
            _bannerService.TCreate(banner);
            return View(banner);
        }
    }
}
