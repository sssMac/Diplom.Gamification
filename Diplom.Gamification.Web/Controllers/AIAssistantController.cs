using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Application.Services;
using Diplom.Gamification.Application.ViewModels;
using Markdig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Yandex.Alice.Sdk.Models;
using static Google.Apis.Requests.BatchRequest;

namespace Diplom.Gamification.Web.Controllers
{
    public class AIAssistantController : Controller
    {
        private readonly IYandexService _yandexService;

        public AIAssistantController(IYandexService yandexService)
        {
            _yandexService = yandexService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new GPTRequest { Request = ""});
        }

        [HttpPost]
        public async Task<IActionResult> Index(GPTRequest model)
        {
            var res = await _yandexService.GetIntentAsync(model.Request);

            var pipeline = new MarkdownPipelineBuilder().Build();
            ViewBag.Answer = Markdown.ToHtml(res.Result.Alternatives[0].Message.Text, pipeline);
            return View();
        }

        private string ProcessIntent(string intent)
        {
            if (intent == "GetCourseInfo")
            {
                return "Информация о курсе.";
            }

            return "Я не понимаю ваш запрос.";
        }
    }
}
