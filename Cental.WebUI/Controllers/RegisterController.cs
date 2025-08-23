using AutoMapper;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class RegisterController(UserManager<AppUser> _usermanager, IMapper _mapper) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //bir kucuk harf buyuk harf rakam ve ozel karakter en az 6 karakter
            var result = await _usermanager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);

                }

            }
            return RedirectToAction("Index", "Login");
        }
    }
}



