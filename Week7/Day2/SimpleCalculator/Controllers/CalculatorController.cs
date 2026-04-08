using Microsoft.AspNetCore.Mvc;

namespace SimpleCalculator.Controllers
{
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        // GET: Show calculator form
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Calculate and display result
        [Route("Index")]
        [HttpPost]
        public IActionResult Index(int num1, int num2)
        {
            int result = num1 + num2;
            ViewData["Result"] = result;
            ViewData["Num1"] = num1;
            ViewData["Num2"] = num2;
            return View();
        }
    }
}