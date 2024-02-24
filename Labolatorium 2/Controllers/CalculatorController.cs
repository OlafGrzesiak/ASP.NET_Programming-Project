using Labolatorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_2.Controllers;

public enum Operators
{
    ADD, SUB, MUL, DIV
}

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Form()
    {
        return View();
    }


    /* public IActionResult Result([FromQuery(Name = "operator")] Operators? op, double? x, double? y)
     {
         if(x == null || y == null)
         {
             return View("Error");
         }
         switch(op)
         {
             case Operators.ADD:
                 ViewBag.result = x + y;
                 break;
             case Operators.SUB:
                 ViewBag.result = x - y;
                 break;
             case Operators.MUL:
                 ViewBag.result = x * y;
                 break;
             case Operators.DIV:
                 ViewBag.result = x / y;
                 break;
             default: return View("Error");
         }
         return View();
     }*/
    public IActionResult Result(Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }


}