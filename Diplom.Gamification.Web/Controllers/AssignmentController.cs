using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Application.ViewModels;
using Diplom.Gamification.Shared;
using Markdig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Diplom.Gamification.Web.Controllers
{
    public class AssignmentController : Controller
    {
        public List<AssignmentTestViewModel?> Tests { get; set; }

        private readonly ILogger<AssignmentController> _logger;
        private readonly IEducationService _educationService;
        private readonly IAssignmentResultService _assignmentResultService;
		private readonly UserManager<ApplicationUser> _userManager;
        private readonly IYandexService _yandexService;
        public AssignmentController(
            ILogger<AssignmentController> logger,
            IEducationService educationService,
            IAssignmentResultService assignmentResultService,
            UserManager<ApplicationUser> userManager,
            IYandexService yandexService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _educationService = educationService ?? throw new ArgumentNullException(nameof(educationService));
            Tests = new();
            _assignmentResultService = assignmentResultService ?? throw new ArgumentNullException(nameof(assignmentResultService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _yandexService = yandexService ?? throw new ArgumentNullException(nameof(yandexService));
        }

        async Task<string> Build()
        {
            return await Compile("dotnet.exe", @"build ..\Diplom.Gamification.CompilerApp\Diplom.Gamification.CompilerApp.csproj");
        }

		async Task<string> Run(string args = "")
        {
            return await Compile(@"..\Diplom.Gamification.CompilerApp\out\Diplom.Gamification.CompilerApp.exe", args);
        }

        async Task<string> Compile(string filename, string args = "")
        {
            var psi = new ProcessStartInfo()
            {
                FileName = filename,
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
            };

            var proc = Process.Start(psi);
            string output = await proc.StandardOutput.ReadToEndAsync();

            using (StreamReader s = proc.StandardError)
            {
                string error = await s.ReadToEndAsync();
                proc.WaitForExit(20000);
                if (error.Length != 0) return error;
            }
            return output;
        }

        public async Task<IActionResult> Index(Guid assignmentid)
        {
            var model = await _educationService.GetAssignmentById(assignmentid);

			ViewBag.Tests = JsonConvert.SerializeObject(model.AssignmentTest);
			ViewBag.Assignmentid = assignmentid;

			return View(model);
        }

		[HttpPost]
		public async Task<TestResultModel> RunTests(string tests, string assignmentId)
        {
			Tests = new List<AssignmentTestViewModel?> { JsonConvert.DeserializeObject<AssignmentTestViewModel>(tests) };

			Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            int passed = 0;
            for (int i = 0; i < Tests.Count; i++)
            {
                var resultModel = await RunCode(args: Tests[i].Input);
                if (!resultModel.BuildSucceed)
                {
                    continue;
                }
                var result = resultModel.Result.Replace("\r\n", " ").Trim();
                if (result == Tests[i].Output.Trim())
                {
                    passed++;
                }
            }
            sw.Stop();

            if(passed == Tests.Count)
            {
                await _assignmentResultService.SuccessAssignment(Guid.Parse(assignmentId), (await _userManager.FindByNameAsync(User.Identity.Name)).Id);
            }

            return new TestResultModel()
            {
                Passed = passed,
                ElapsedTime = sw.Elapsed.ToString(),
                Total = Tests.Count
            };
        }

        [HttpPost]
        public async Task<CompilationResultModel> RunCode(string tests = "", string args = "")
        {
            if(tests != "")
            {
			    Tests = new List<AssignmentTestViewModel?> { JsonConvert.DeserializeObject<AssignmentTestViewModel>(tests) };
            }

			Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var runResult = await Run(args.Length == 0 ? Tests[0].Input : args);
            sw.Stop();

            var result = new CompilationResultModel();

            if (runResult.Contains("Unhandled exception"))
            {
                result.BuildSucceed = false;
                var error = new ErrorModel();
                runResult!
                    .Split('\n').ToList()
                    .ForEach(line =>
                    {
                        if (line.Contains(@"Unhandled exception"))
                        {
                            var message = line.Trim();

                            error.ErrorMessage = message;
                        }
                        if (line.Contains("Program.cs:line"))
                        {
                            error.Line = int.Parse(line.Split("Program.cs:line")[1].Trim());
                        }
                        result.Result = "";
                    });
                result.Errors.Add(error);
                result.BuildSucceed = false;
            }
            else
            {
                result.BuildSucceed = true;
                result.Result = runResult;
            }

            result.ElapsedTime = sw.Elapsed.ToString();

            return result;
        }

        [HttpPost]
        public async Task<CompilationResultModel> CompileCode(string code, string tests)
        {
            System.IO.File.WriteAllText(@"..\Diplom.Gamification.CompilerApp\Program.cs", code);

			Tests = new List<AssignmentTestViewModel?> { JsonConvert.DeserializeObject<AssignmentTestViewModel>(tests) };

			var buildResult = await Build();

            var result = new CompilationResultModel();

            if (buildResult.Contains("Ошибка сборки."))
            {
                result.BuildSucceed = false;
                buildResult
                    .Split("Ошибка сборки.")[1]
                    .Trim()
                    .Split('\n').ToList()
                    .ForEach(line =>
                    {
                        if (line.Contains(@"Diplom.Gamification.CompilerApp\Program.cs"))
                        {
                            var message = line.Split(@"Diplom.Gamification.CompilerApp\Program.cs")[1].Split(@"[")[0].Trim();
                            var regexMessage = Regex.Match(message, @"\((?<line>\d+),(?<column>\d+)\):(?<message>.+)");
                            result.Errors.Add(new ErrorModel()
                            {
                                ErrorMessage = regexMessage.Groups["message"].Value.Trim(),
                                Line = int.Parse(regexMessage.Groups["line"].Value),
                                Column = int.Parse(regexMessage.Groups["column"].Value),
                            });
                        }
                        if (line.Contains("Прошло времени"))
                        {
                            result.ElapsedTime = line.Split("Прошло времени")[1].Trim();
                        }
                        result.Result = "";
                    });
            }
            else
            {
                result.ElapsedTime = buildResult.Split("Прошло времени")[1].Trim();
                result.BuildSucceed = true;
                var res = await _yandexService.GetCodeSkillAsync(code);

                var pipeline = new MarkdownPipelineBuilder().Build();
                result.CodeSkill = Markdown.ToHtml(res.Result.Alternatives[0].Message.Text, pipeline);
            }

            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task TimeTest(string code, string tests)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int numThreads = 5;

            Task[] tasks = new Task[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                int threadIndex = i; 
                tasks[i] = Task.Run(() => CompileCode(code, tests));
            }

            Task.WaitAll(tasks);

            stopwatch.Stop();

            Console.WriteLine($"{numThreads} methods have completed.");
            Console.WriteLine("Total execution time: " + stopwatch.Elapsed);
        }
    }
}
