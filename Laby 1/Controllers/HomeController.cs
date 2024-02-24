using Laby_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laby_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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

        public IActionResult About(string author)
        {
            //string author = Request.Query["author"];
            ViewBag.Author = author;
            return View();
        }

        public IActionResult Calculator([FromQuery(Name = "operator")] string op, double? x, double? y)
        {
            if (x == null || y == null)
            {
                return View("Error");
            }
            if (op == "add")
            {
                ViewBag.Result = x + y;
            }
            if (op == "sub")
            {
                ViewBag.Result = x - y;
            }
            if (op == "mul")
            {
                ViewBag.Result = x * y;
            }
            if (op == "div")
            {
                ViewBag.Result = x / y;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}