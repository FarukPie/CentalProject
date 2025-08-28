using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminLayoutSidebarComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.nameSurname = $"{user.FirstName} {user.LastName}";
            ViewBag.userImg = user.ImageUrl;
            return View();
        }
    }
}
