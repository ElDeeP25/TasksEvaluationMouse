using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksEvaluation.Web.ViewModel;

namespace TasksEvaluation.Web.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var Roles = await _roleManager.Roles.Select(x => new RoleViewModel()
                {

                    id = x.Id,
                    RoleName = x.Name
                }).ToListAsync();
                return View(Roles);
            }

            else
            {
                var role = await _roleManager.FindByNameAsync(name);

                var mappedrole = new RoleViewModel()
                {
                    id = role.Id,
                    RoleName = role.Name
                };

                return View(new List<RoleViewModel>() {mappedrole });
            }
            return View();

        }













        public IActionResult Index()
        {
            return View();
        }


    }
}
