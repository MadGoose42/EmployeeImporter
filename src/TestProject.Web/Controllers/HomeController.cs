using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestProject.Core.Interfaces;
using TestProject.Web.Models;

namespace TestProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeProcessor processor;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IEmployeeProcessor processor, ILogger<HomeController> logger)
        {
            this.processor = processor;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromForm]UploadModel uploadModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var saved = await processor.Process(uploadModel.CsvFile.OpenReadStream());
            return View("DisplayResult", saved.ToArray());
        }
    }
}