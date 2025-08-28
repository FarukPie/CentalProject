using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> _signInmanager) : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto model, string? returnUrl)
        {
            var result = await _signInmanager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {   
                ModelState.AddModelError(string.Empty, "username or password is wrong");
                return View(model);
            }
            if (returnUrl != null) {
                return Redirect(returnUrl);
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
