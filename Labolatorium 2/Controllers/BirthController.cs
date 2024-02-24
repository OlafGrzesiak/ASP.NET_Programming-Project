using Labolatorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Result(Birth model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }



        public IActionResult BirthForm()
        {
            return View();
        }
        public IActionResult UserData()
        {
            return View();
        }
    }
}
