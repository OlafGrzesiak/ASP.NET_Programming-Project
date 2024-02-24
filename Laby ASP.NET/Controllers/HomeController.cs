using Laby_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Laby_ASP.NET.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Calculator(Operator op, double? a, double? b)
        {
            ViewBag.a = a; ViewBag.b = b;
            ViewBag.Op = op;
            if (op == null)
            {
                ViewBag.KalkulatorErrorMessage = "no operator provided";
            }
            if (a == null || b == null)
            {
                return View("Error");
            }
            // zbiór operatorów: add, sub, mul, div
            if (op == Operator.Add)
            {
                ViewBag.Result = a + b;
            }
            else if (op == Operator.Sub) 
            {
                ViewBag.Result = a - b;
            }
            else if (op == Operator.Mul)
            {
                ViewBag.Result = a * b;
            }
            else if (op == Operator.Div)
            {
                ViewBag.Result = a / b;
            }
            return View();
        }

        public enum Operator
        {
            Unknown, Add, Mul, Sub, Div
        }

    }
}