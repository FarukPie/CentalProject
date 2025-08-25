using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class LoginController(SignInManager<AppUser> _signInmanager) : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto model)
        {
            var result = await _signInmanager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {   
                ModelState.AddModelError(string.Empty, "username or password is wrong");
                return View(model);
            }
            return RedirectToAction("Index", "AdminAbout");
        }
        public async Task<ActionResult> Logout()
        {
            await _signInmanager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
