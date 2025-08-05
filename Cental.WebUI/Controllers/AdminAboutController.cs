using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutservice;

        public AdminAboutController(IAboutService aboutservice)
        {
            _aboutservice = aboutservice;
        }

        public IActionResult Index()
        {
            var values =_aboutservice.TGetAll();
            return View(values);
        }
    }
}
