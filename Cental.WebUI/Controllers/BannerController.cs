using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.AboutDtos;
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
        [HttpGet]
        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF koruması
        public IActionResult CreateBanner(CreateBannerDto model)
        {
            if (!ModelState.IsValid)
            {
                // Model geçerli değilse formu tekrar göster
                return View(model);
            }

            var banner = _mapper.Map<Banner>(model); 
            _bannerService.TCreate(banner);

            // Kaydettikten sonra liste sayfasına yönlendir
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var entity = _bannerService.TGetById(id);
            var dto = _mapper.Map<ResultBannerDto>(entity); // Entity → DTO
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBanner(UpdateBannerDto model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var banner = _mapper.Map<Banner>(model); // DTO → Entity
            _bannerService.TUpdate(banner);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteBanner(int id)
        {
            _bannerService.TDelete(id);
            return RedirectToAction("Index");
        }


    }
}
