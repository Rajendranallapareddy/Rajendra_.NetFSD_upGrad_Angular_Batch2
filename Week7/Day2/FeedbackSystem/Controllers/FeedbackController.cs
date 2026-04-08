using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.Controllers
{
    [Route("[controller]")]
    public class FeedbackController : Controller
    {
        // GET: Show feedback form
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Process feedback and show message
        [Route("Index")]
        [HttpPost]
        public IActionResult Index(string name, string comments, int rating)
        {
            ViewData["Name"] = name;
            ViewData["Comments"] = comments;
            ViewData["Rating"] = rating;
            
            // Conditional message based on rating
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your wonderful feedback! 🙏";
                ViewData["MessageClass"] = "thankyou";
            }
            else
            {
                ViewData["Message"] = "We will improve our services based on your feedback! 💪";
                ViewData["MessageClass"] = "improve";
            }
            
            return View();
        }
    }
}