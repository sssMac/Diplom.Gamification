using Diplom.Gamification.Application.Consts;
using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Application.ViewModels;
using Diplom.Gamification.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Gamification.Web.Controllers
{
    [Authorize]
    public class CreatorController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CreatorController(IEducationService educationService, UserManager<ApplicationUser> userManager)
        {
            _educationService = educationService ?? throw new ArgumentNullException(nameof(educationService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _educationService.GetMyCourses(_userManager.GetUserId(User));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> NewCourse()
        {
            return View(new AddCourseViewModel { Level = 1});
        }

        [HttpPost]
        public async Task<IActionResult> NewCourse(AddCourseViewModel model, ButtonAction buttonAction = ButtonAction.Save)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = _userManager.GetUserId(User);

                var result = await _educationService.AddCourse(model);
                if (result.Success)
                {
                    if(buttonAction == ButtonAction.Save)
                    {
                        return RedirectToAction("Index");
                    }
                    else if(buttonAction == ButtonAction.Continue)
                    {
                        return RedirectToAction("NewLesson", result.CreatedId);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.Error);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> NewLesson(Guid id)
        {
            return View(new AddLessonViewModel { CourseId = id, Assignment = new AddAssignmentViewModel()});
        }

        [HttpPost]
        public async Task<IActionResult> NewLesson(AddLessonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _educationService.AddLesson(model);
                if (result.Success)
                {
                    return RedirectToAction("Course", "Education", model.CourseId);
                }
                else
                {
                    ModelState.AddModelError("", result.Error);
                }
            }
            return View(model);
        }
    }
}
