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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _mapper.Map<AppUser>(model);

            // Kullanıcıyı oluştur
            var result = await _usermanager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Başarılıysa login sayfasına yönlendir
                return RedirectToAction("Index", "Login");
            }

            // Başarısızsa hataları modele ekle
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            // Aynı sayfayı geri döndür, hatalar View’da gözüksün
            return View(model);
        }

    }
}



