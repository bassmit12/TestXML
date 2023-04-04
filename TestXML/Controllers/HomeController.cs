using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestXML.Models;

namespace TestXML.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(IFormFile xmlFile)
        {
            var model = new XmlModel();
            if (xmlFile != null && xmlFile.Length > 0)
            {
                using (var reader = new StreamReader(xmlFile.OpenReadStream()))
                {
                    model.Content = reader.ReadToEnd();
                }
            }
            return View(model);
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
    }
}