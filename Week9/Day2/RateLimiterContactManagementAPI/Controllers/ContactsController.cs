using Microsoft.AspNetCore.Mvc;
using ContactManagementAPI.Models;

namespace ContactManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact { ContactId = 1, Name = "Kartik", Email = "kartik@gmail.com", Phone = "9999999999" },
            new Contact { ContactId = 2, Name = "Rahul", Email = "rahul@gmail.com", Phone = "8888888888" }
        };

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(contacts);
        }
    }
}