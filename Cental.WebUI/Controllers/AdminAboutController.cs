using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize]
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
            var result = values.Select(about => new ResultAboutDto
            {
                AboutID = about.AboutID,
                Vision = about.Vision,
                Mission = about.Mission
            }).ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();

        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto about)
        {
           
            _aboutservice.TCreate(new About
            {
                Description1 = about.Description1,
                Description2 = about.Description2,
                ImageUrl1 = about.ImageUrl1,
                ImageUrl2 = about.ImageUrl2,
                item1 = about.item1,
                item2 = about.item2,
                item3 = about.item3,
                item4 = about.item4,
                JobTitle = about.JobTitle,
                Mission = about.Mission,
                NameSurname = about.NameSurname,
                ProfilePic = about.ProfilePic,
                StartYear = about.StartYear,
                Vision = about.Vision
            });
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAbout(int id)
        {
            _aboutservice.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var model = _aboutservice.TGetById(id);
            var about = new UpdateAboutDto
            {
                AboutID = model.AboutID,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                item1 = model.item1,
                item2 = model.item2,
                item3 = model.item3,
                item4 = model.item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePic = model.ProfilePic,
                StartYear = model.StartYear,
                Vision = model.Vision

            };
            return View(about);

        }
        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto model)
        {
            var about = new About
                {
                AboutID = model.AboutID,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                item1 = model.item1,
                item2 = model.item2,
                item3 = model.item3,
                item4 = model.item4,
                JobTitle = model.JobTitle,
                Mission = model.Mission,
                NameSurname = model.NameSurname,
                ProfilePic = model.ProfilePic,
                StartYear = model.StartYear,
                Vision = model.Vision

            };
            _aboutservice.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
