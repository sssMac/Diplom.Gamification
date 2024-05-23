using Diplom.Gamification.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplom.Gamification.Web.Controllers
{
    public class RatingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.OrderByDescending(x => x.Rating).ToListAsync());
        }
    }
}
