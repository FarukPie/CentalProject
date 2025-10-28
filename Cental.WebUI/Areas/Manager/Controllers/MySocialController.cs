using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class MySocialController(IUserSocialService _userSocialService, IMapper _mapper, UserManager<AppUser> _usermanager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _usermanager.FindByIdAsync(User.Identity.Name);
            var values=_userSocialService.TGetSocialsByUserId(user.Id);
            return View(values);
        }

        public IActionResult CreateSocial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateSocialUserDto model)
        {
            var user = await _usermanager.FindByIdAsync(User.Identity.Name);
            var newSocial=_mapper.Map<UserSocial>(model);
            _userSocialService.TCreate(newSocial);
            return RedirectToAction("Index");
        }
    }
}
