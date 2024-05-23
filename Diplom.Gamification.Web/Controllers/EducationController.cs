using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Application.ViewModels;
using Diplom.Gamification.Infrastructure.Services;
using Diplom.Gamification.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Diplom.Gamification.Web.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _identityService;

        public EducationController(IEducationService educationService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> identityService)
        {
            _educationService = educationService ?? throw new ArgumentNullException(nameof(educationService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if(User.Identity.Name is null)
            {
                await _identityService.SignOutAsync();
                return RedirectToAction("Login", "Auth");
            }
            var model = await _educationService.GetCourses(true, (await _userManager.FindByNameAsync(User.Identity.Name)).Id);
            return View(model);
        }

        #region Course

        [HttpGet]
        public async Task<IActionResult> Course(Guid id)
        {
            var model = await _educationService.GetCourseById(id, true);

            model.Description = RegexParse(model.Description);

            var user = await _userManager.FindByIdAsync(model.CreatedBy);

            model.CreatorUserName = string.IsNullOrEmpty(user.UserName) ? "Анонимный пользователь" : user.UserName;
            model.AvatarLink = user.AvatarLink;

            return View(model);
        }

        #endregion

        #region Lesson

        [HttpGet]
        public async Task<IActionResult> Lesson(Guid Id)
        {
            var model = await _educationService.GetLessonsById(Id, true);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLesson(Guid courseId) 
        {
            return View(new AddLessonViewModel { CourseId = courseId});
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson(AddLessonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _educationService.AddLesson(model);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Error);
                }
            }

            return View(model);
        }

        #endregion

        private string RegexParse(string description)
        {
            var pattern = @"<figure[^>]*><oembed url=""(https:\/\/www\.youtube\.com\/watch\?v=)([^""]+)""[^>]*><\/oembed><\/figure>";

            Regex.Matches(description, pattern)
                .ToList()
                .ForEach(v =>
                {
                    var id = v.Groups[2].Value;
                    description = description.Replace(v.Value, @$"<iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/{id}"" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"" allowfullscreen></iframe>");
                });

            return description;
        }

    }
}
