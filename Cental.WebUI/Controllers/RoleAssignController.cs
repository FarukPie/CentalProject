using Cental.DTOLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    public class RoleAssignController(UserManager<AppUser> _userManager, RoleManager<AppRole> _rolemanager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDto = new List<ResultUserDto>();
            foreach (var user in users)
            {
                var dto = new ResultUserDto();

                dto.Roles = await _userManager.GetRolesAsync(user);

                dto.FirstName = user.FirstName;
                dto.LastName = user.LastName;
                dto.UserName = user.UserName;
                dto.Id = user.Id;
                dto.Email = user.Email;
                userDto.Add(dto);   
            }

            return View(userDto);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());


            ViewBag.FullName = string.Join(" ", user.FirstName, user.LastName);
            var roles = await _rolemanager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var assignRoleDtoList = new List<AssignRoleDto>();

            var assignRoleDto = new List<AssignRoleDto>();
            foreach (var role in roles)
            {
                var model = new AssignRoleDto();
                model.UserId = user.Id;
                model.RoleName = role.Name;
                model.RoleId = role.Id;
                model.RoleExist = userRoles.Contains(role.Name);

                assignRoleDtoList.Add(model);
            }
            return View(assignRoleDtoList);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
        {
            var userId = model.Select(x => x.UserId).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
