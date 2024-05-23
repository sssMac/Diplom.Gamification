using Diplom.Gamification.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Gamification.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                var userName = User.Identity.Name;
                id = (await _userManager.FindByNameAsync(userName)).Id;
            }
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }
    }
}
