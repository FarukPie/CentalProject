using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminProfileController(UserManager<AppUser> _usermanager, IImageService _imageservice) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _usermanager.FindByNameAsync(User.Identity.Name);
            var profileEditDto = user.Adapt<ProfileEditDto>();
            return View(profileEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditDto model)
        {
            var user = await _usermanager.FindByNameAsync(User.Identity.Name);

            var succeed = await _usermanager.CheckPasswordAsync(user, model.CurrentPassword);
            if (succeed)
            {
                if (model.ImageFile != null) {
                    model.ImageUrl = await _imageservice.SaveImageAsync(model.ImageFile);
                }


                var updateUser = model.Adapt<AppUser>();
                var result = await _usermanager.UpdateAsync(updateUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "AdminAbout");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View(model);
            }
            ModelState.AddModelError(string.Empty, "this password is wrong");
            return View(model);
        }
    }
}
