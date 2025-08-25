using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponent(UserManager<AppUser> _userManager):ViewComponent
    {
        public async Task<IViewComponentResult> Invoke()
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);
            ViewBag.nameSurname = string.Join(" ", user.FirstName, user.LastName);
            ViewBag.userImg = user.ImageUrl;
            return View();
        }
    }
}
