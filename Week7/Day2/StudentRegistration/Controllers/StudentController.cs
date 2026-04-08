using Microsoft.AspNetCore.Mvc;

namespace StudentRegistration.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        // GET: Show registration form
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Handle form submission and redirect to display
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(string studentName, int age, string course)
        {
            // Store data in ViewBag/ViewData
            ViewBag.StudentName = studentName;
            ViewBag.Age = age;
            ViewBag.Course = course;

            // Redirect to Display action
            return RedirectToAction("Display");
        }

        // GET: Display submitted data
        [Route("Display")]
        [HttpGet]
        public IActionResult Display()
        {
            return View();
        }
    }
}